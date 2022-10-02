namespace TaskManagementSystem.Data.DBAccess
{
    public interface ITaskDataAccess: IDataAccess
    {
        Task<(IEnumerable<Entities.Models.Task> tasks, IEnumerable<Entities.Models.Comment> comments)> GetMultipleDataBySp<U>(string sp, U param, string splitBy, string connId = "TaskDb");
    }
}