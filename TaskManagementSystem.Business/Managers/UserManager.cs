using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Data.DBAccess;
using TaskManagementSystem.Entities.Models;

namespace TaskManagementSystem.Business.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IDataAccess _dataAccess;

        public UserManager(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _dataAccess.GetDataByQuery<User, dynamic>("SELECT * FROM dbo.Users", new { });
        }
        public async Task<User?> GetUserAsync(int id)
        {
            var res = await _dataAccess.GetDataByQuery<User, dynamic>("SELECT * FROM Users WHERE Id=@Id", new { Id = id });
            return res.FirstOrDefault();
        }
        public async Task<User?> GetUserByUserNamePassAsync(string userName,string password)
        {
            var res = await _dataAccess.GetDataByQuery<User, dynamic>("SELECT * FROM Users WHERE UserName=@userName AND Password=@password", new { UserName= userName, Password = password });
            return res.FirstOrDefault();
        }
    }
}
