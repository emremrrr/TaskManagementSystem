using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace TaskManagementSystem.Data.DBAccess
{
    public class TaskDataAccess : DataAccess, ITaskDataAccess
    {
        private readonly IConfiguration _configuration;

        public TaskDataAccess(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        public async Task<(IEnumerable<Entities.Models.Task> tasks, IEnumerable<Entities.Models.Comment> comments)> GetMultipleDataBySp<U>(string sp, U param, string splitBy, string connId = "TaskDb")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connId));
            GridReader reader = await connection.QueryMultipleAsync(sp, param, commandType: CommandType.StoredProcedure);
            var firstList = reader.Read<Entities.Models.Task, Entities.Models.User, Entities.Models.Task>((t, u) =>
            {
                t.User = u;
                return t;
            },
                splitOn: "AssignedTo"
            );
            var secondList = reader.Read<Entities.Models.Comment, Entities.Models.User, Entities.Models.Comment>((c, u) =>
            {
                c.User = u;
                return c;
            },
                splitOn: "CreatedBy"
            );
            //var firstList = await reader.ReadAsync<Entities.Models.Task>();
            //var secondList = await reader.ReadAsync<Entities.Models.Comment>();
            return (firstList, secondList);
        }
    }
}
