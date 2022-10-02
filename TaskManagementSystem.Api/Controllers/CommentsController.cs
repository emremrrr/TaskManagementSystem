using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Business.Managers;
using TaskManagementSystem.Entities.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentManager _commentManager;

        public CommentsController(ICommentManager commentManager)
        {
            _commentManager = commentManager;
        }



    }
}
