using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Business.Managers;
using TaskManagementSystem.Entities.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await _userManager.GetUsersAsync();
                if (res.Count() == 0)
                {
                    return NoContent();
                }
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
                var res = await _userManager.GetUserAsync(id);
                if (res == null)
                {
                    return NoContent();
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
