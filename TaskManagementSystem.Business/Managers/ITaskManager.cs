namespace TaskManagementSystem.Business.Managers
{
    public interface ITaskManager
    {
        Task<bool> CheckIfTaskExists(int id);
        Task<Entities.Models.Task?> GetTaskAsync(int id);
        Task<IEnumerable<Entities.Models.Task>> GetTasksAsync();
        Task<int> UpsertTaskAsync(Entities.Models.TaskBase task);
    }
}