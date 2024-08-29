using Clinic.API.Models;
using Clinic.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            if (loginModel.UserName == "malkabr" && loginModel.Password == "123456")
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "malkabr"),
                new Claim(ClaimTypes.Role, "teacher")
            };

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: _configuration.GetValue<string>("JWT:Issuer"),
                    audience: _configuration.GetValue<string>("JWT:Audience"),
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(6),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            return Unauthorized();
        }
    }

}



//הגדרת שם וסיסמה לפי לקיחה מהדטה בייס
//namespace Clinic.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthController : ControllerBase
//    {
//        private readonly IConfiguration _configuration;
//        private readonly IUserService _userService;

//        public AuthController(IConfiguration configuration, IUserService userService)
//        {
//            _userService = userService;
//            _configuration = configuration;
//        }

//        [HttpPost]
//        public async IActionResult Login([FromBody] LoginModel loginModel)
//        {
//            var users= await _userService.GetAllAsync();
//            var user = users.First(u => u.Name == loginModel.UserName && u.Password == loginModel.Password);
//            if (user is not null)
//            {
//                var claims = new List<Claim>()
//            {
//                new Claim("Name", user.Name),
//                new Claim("Email", user.Email)
//            };

//                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
//                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
//                var tokeOptions = new JwtSecurityToken(
//                    issuer: _configuration.GetValue<string>("JWT:Issuer"),
//                    audience: _configuration.GetValue<string>("JWT:Audience"),
//                    claims: claims,
//                    expires: DateTime.Now.AddMinutes(6),
//                    signingCredentials: signinCredentials
//                );
//                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
//                return Ok(new { Token = tokenString });
//            }
//            return Unauthorized();
//        }
//    }

//}
