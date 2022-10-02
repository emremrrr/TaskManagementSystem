using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Api.Models;
using TaskManagementSystem.Business.Helpers;
using TaskManagementSystem.Business.Managers;

namespace TaskManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IJwt _jwt;

        public AuthController(IUserManager userManager, IJwt jwt)
        {
            _userManager = userManager;
            _jwt = jwt;
        }

        [HttpPost]
        public async Task<IActionResult> GetToken([FromBody] UserModel user)
        {
            try
            {
                var res = await _userManager.GetUserByUserNamePassAsync(user.UserName, user.Password);
                if (res == null)
                    return NoContent();

                string token = _jwt.GetJwtToken(res);
                return Ok(new {token=token});

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
