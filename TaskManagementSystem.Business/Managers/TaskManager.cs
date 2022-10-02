using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Data.DBAccess;

namespace TaskManagementSystem.Business.Managers
{
    public class TaskManager : ITaskManager
    {
        private readonly IDataAccess _dataAccess;
        private readonly ITaskDataAccess _taskDataAccess;

        public TaskManager(IDataAccess dataAccess, ITaskDataAccess taskDataAccess)
        {
            _dataAccess = dataAccess;
            _taskDataAccess = taskDataAccess;
        }

        public async Task<IEnumerable<Entities.Models.Task>> GetTasksAsync()
        {
            return await _dataAccess.GetDataBySpWithRelationship<Entities.Models.Task, Entities.Models.User, dynamic>("[dbo].[spTasks_Get]", new { }, "AssignedTo");
        }
        public async Task<Entities.Models.Task?> GetTaskAsync(int _id)
        {
            var x = await _taskDataAccess.GetMultipleDataBySp<dynamic>("[dbo].[spTask_Get]", new { id = _id }, "AssignedTo");
            var res = x.tasks.FirstOrDefault();

            res.Comments = x.comments.ToList();
            return res;
        }
        public async Task<int> UpsertTaskAsync(Entities.Models.TaskBase task)
        {
            var res = await _dataAccess.InsertData<dynamic>("[dbo].[spTask_Upsert]",
                new
                {
                    id = task.Id,
                    created = task.Created,
                    requiredDate = task.RequiredDate,
                    taskStatus = task.TaskStatus,
                    taskType = task.TaskType,
                    assignedTo = task.AssignedTo,
                    nextActionDate = task.NextActionDate,
                    taskDescription = task.TaskDescription,
                });
            return res;
        }

        public async Task<bool> CheckIfTaskExists(int id)
        {
            var res = await _dataAccess.GetDataByQuery<int, dynamic>("SELECT COUNT(1) FROM [dbo].[Tasks] WHERE Id=@id", new { id = id });
            return res.FirstOrDefault() > 0;
        }
    }
}
