namespace TaskManagementSystem.Data.DBAccess
{
    public interface IDataAccess
    {
        Task<IEnumerable<T>> GetDataBySp<T, U>(string sp, U param, string connId = "TaskDb");
        Task<IEnumerable<T>> GetDataBySpWithRelationship<T, R, U>(string sp, U param, string splitBy, string connId = "TaskDb");
        Task<(IEnumerable<T1>, IEnumerable<T2>)> GetMultipleDataBySpWithRelationship<T1, T2, R, U>(string sp, U param, string splitBy, string connId = "TaskDb");
        Task<int> InsertData<U>(string sp, U param, string connId = "TaskDb");
        Task<IEnumerable<T>> GetDataByQuery<T, U>(string command, U param, string connId = "TaskDb");
        Task<int> ExecuteByQuery<U>(string command, U param, string connId = "TaskDb");
    }
}