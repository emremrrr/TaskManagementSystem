using Dapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskManagementSystem.Data.DBAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration _configuration;

        public DataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> GetDataBySp<T, U>(string sp, U param, string connId = "TaskDb")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connId));
            return await connection.QueryAsync<T>(sp, param, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<T>> GetDataBySpWithRelationship<T, R, U>(string sp, U param, string splitBy, string connId = "TaskDb")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connId));
            return await connection.QueryAsync<T, R, T>(sp, (t, r) =>
            {
                t.GetType().GetProperty(typeof(R).Name).SetValue(t, r);
                return t;
            }, param,
            splitOn: splitBy,
            commandType: CommandType.StoredProcedure
            );
        }
        public virtual async Task<(IEnumerable<T1>,IEnumerable<T2>)> GetMultipleDataBySpWithRelationship<T1,T2, R, U>(string sp, U param, string splitBy, string connId = "TaskDb")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connId));
            var reader=await connection.QueryMultipleAsync(sp, param,commandType: CommandType.StoredProcedure);
            var firstList=await reader.ReadAsync<T1>();
            var secondList=await reader.ReadAsync<T2>();
            return (firstList,secondList);

        }
        public async Task<int> InsertData<U>(string sp, U param, string connId = "TaskDb")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connId));
            return await connection.ExecuteAsync(sp, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<T>> GetDataByQuery<T, U>(string command, U param, string connId = "TaskDb")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connId));
            return await connection.QueryAsync<T>(command, param, commandType: CommandType.Text);
        }
        public async Task<int> ExecuteByQuery<U>(string command, U param, string connId = "TaskDb")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connId));
            return await connection.ExecuteAsync(command, param, commandType: CommandType.Text);
        }
    }
}
