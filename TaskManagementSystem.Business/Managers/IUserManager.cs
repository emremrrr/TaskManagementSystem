using TaskManagementSystem.Entities.Models;

namespace TaskManagementSystem.Business.Managers
{
    public interface IUserManager
    {
        Task<User?> GetUserAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User?> GetUserByUserNamePassAsync(string userName, string password);
    }
}