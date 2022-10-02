using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Business.Helpers
{
    public class Jwt : IJwt
    {
        private JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly IConfiguration _configuration;

        public Jwt(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string GetJwtToken(Entities.Models.User user)
        {
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var symetricKey = Convert.FromBase64String(_configuration["Keys:Secret"]);
            var securityToken = _jwtSecurityTokenHandler.CreateToken(
                new SecurityTokenDescriptor
                {
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symetricKey), SecurityAlgorithms.HmacSha256Signature),
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name,user.UserName),
                        new Claim("Id",user.Id.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddHours(180)
                });
            return _jwtSecurityTokenHandler.WriteToken(securityToken);
        }
    }
}
