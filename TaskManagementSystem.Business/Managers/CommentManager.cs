using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Data.DBAccess;

namespace TaskManagementSystem.Business.Managers
{
    public class CommentManager : ICommentManager
    {
        private readonly IDataAccess _dataAccess;

        public CommentManager(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<bool> CheckIfCommentExists(int id)
        {
            var res = await _dataAccess.GetDataByQuery<int, dynamic>("SELECT COUNT(1) FROM [dbo].[Comments] WHERE Id=@id", new { id = id });
            return res.FirstOrDefault()>0;
        }
        public async Task<IEnumerable<Entities.Models.Comment>> GetCommentsAsync(int taskId,string searchText=null)
        {
            return await _dataAccess.GetDataBySpWithRelationship<Entities.Models.Comment, Entities.Models.User, dynamic>("[dbo].[spComments_Get]", searchText==null? new { taskId = taskId } : new { taskId = taskId, searchText= searchText }, "CreatedBy");
        }
        public async Task<Entities.Models.Comment?> GetCommentAsync(int taskId ,int id)
        {
            var res = await _dataAccess.GetDataBySpWithRelationship<Entities.Models.Comment, Entities.Models.User, dynamic>("[dbo].[spComment_Get]", new { taskId= taskId, id = id }, "CreatedBy");
            return res.FirstOrDefault();
        }
        public async Task<int> UpsertCommentAsync(int taskId,Entities.Models.CommentBase comment)
        {
            var res = await _dataAccess.InsertData<dynamic>("[dbo].[spComment_Upsert]",
                new
                {
                    id = comment.Id,
                    created = comment.Created,
                    reminderDate = comment.ReminderDate,
                    commentText = comment.CommentText,
                    commentType = comment.CommentType,
                    taskId = taskId,
                    createdBy = comment.CreatedBy,

                });
            return res;
        }

        public async Task<int> RemoveCommentsAsync(int taskId,int id)
        {
            return await _dataAccess.ExecuteByQuery<dynamic>("DELETE FROM dbo.Comments WHERE TaskId=@taskId AND Id=@id ", new { taskId= taskId, id = id });
        }
    }
}
