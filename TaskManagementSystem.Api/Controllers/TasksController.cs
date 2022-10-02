using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Business.Managers;
using TaskManagementSystem.Entities.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskManager _taskManager;

        public ICommentManager _commentManager { get; }

        public TasksController(ITaskManager taskManager, ICommentManager commentManager)
        {
            _taskManager = taskManager;
            _commentManager = commentManager;
        }
        // GET: api/<TaskController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await _taskManager.GetTasksAsync();
                if (res.Count() == 0)
                    return NoContent();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var res = await _taskManager.GetTaskAsync(id);
                if (res == null)
                    return NoContent();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<TaskController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Entities.Models.TaskBase task)
        {
            try
            {
                return Ok(await _taskManager.UpsertTaskAsync(task));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{taskId}/comments")]
        public async Task<IActionResult> GetComments(int taskId)
        {
            try
            {
                var res = await _commentManager.GetCommentsAsync(taskId);
                if (res.Count() == 0)
                    return NoContent();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{taskId}/comments/{id}")]
        public async Task<IActionResult> GetCommentById(int taskId, int id)
        {
            try
            {
                var res= await _commentManager.GetCommentAsync(taskId, id);
                if (res == null)
                    return NoContent();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("{taskId}/comments/")]
        public async Task<IActionResult> Post(int taskId, [FromBody] CommentBase comment)
        {
            try
            {
                return Ok(await _commentManager.UpsertCommentAsync(taskId, comment));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{taskId}/comments/{id}")]
        public async Task<IActionResult> Delete(int taskId, int id)
        {
            try
            {
                if (!await _commentManager.CheckIfCommentExists(id))
                    return NoContent();
                return Ok(await _commentManager.RemoveCommentsAsync(taskId, id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{taskId}/comments/search/{searchText}")]
        public async Task<IActionResult> GetCommentsBySearchText(int taskId, string searchText)
        {
            try
            {
                return Ok(await _commentManager.GetCommentsAsync(taskId, searchText));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
