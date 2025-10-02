using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using POSSystem.Application;

namespace POSSystem.API.Controllers
{
        [ApiController]
        [Route("api/auth")]
        public class AuthController : ControllerBase
        {
            private readonly JwtHelper _jwtHelper;

            public AuthController(JwtHelper jwtHelper)
            {
                _jwtHelper = jwtHelper;
            }

            [HttpPost("login")]
            public IActionResult Login([FromBody] LoginModel model)
            {
                if (model.Role =="Admin" && model.Username == "admin" && model.Password == "password")
                {
                    var token = _jwtHelper.GenerateToken(model.Username);
                    return Ok(new { Token = token });
                }

                throw new UnauthorizedAccessException("Invalid Credentials");
            }
        }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }
        }
}
