using Crudoperation.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Crudoperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private User AuthenticateUser(User user)
        {
            User _user = null;
            if (user.Username == "Admin" && user.Password == "Admin123")
            {
                _user = new User { Username = "Eranda" };
            }
            return _user;
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("UserName", user.Username)
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, null,
                expires: DateTime.Now.AddSeconds(30),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]User user)
        {
            IActionResult res = Unauthorized();
            var users = AuthenticateUser(user);

            if (users != null)
            {
                var tokenString = GenerateToken(user);
                res = Ok(new { token = tokenString });
            }
            return res;
        }
    }
}
