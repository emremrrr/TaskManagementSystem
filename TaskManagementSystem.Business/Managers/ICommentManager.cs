using TaskManagementSystem.Entities.Models;

namespace TaskManagementSystem.Business.Managers
{
    public interface ICommentManager
    {
        Task<bool> CheckIfCommentExists(int id);
        Task<Comment?> GetCommentAsync(int taskId, int id);
        Task<IEnumerable<Comment>> GetCommentsAsync(int taskId, string searchText = null);
        Task<int> RemoveCommentsAsync(int taskId, int id);
        Task<int> UpsertCommentAsync(int taskId, Entities.Models.CommentBase comment);

    }
}