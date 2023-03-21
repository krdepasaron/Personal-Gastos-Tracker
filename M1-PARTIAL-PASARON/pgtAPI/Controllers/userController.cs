using PGTLibrary.Data;
using PGTLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace pgtAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private IConfiguration _config;
        private ISqlData _db;

        public userController(IConfiguration config, ISqlData db)
        {
            _config = config;
            _db = db;
        }

        private string GenerateToken(usermodel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            string userIdStr = user.Id.ToString();
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, userIdStr),
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/api/[controller]/login")]

        public ActionResult Login([FromBody] userlogin login)
        {
            usermodel user = _db.verify(login.username, login.password);

            if (user != null)
            {
                var token = GenerateToken(user);
                return Ok(token);
            }

            return NotFound("User not found");
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/api/[controller]/register")]

        public ActionResult Register([FromBody] usermodel user)
        {
            _db.register(user.username, user.firstname, user.lastname, user.password);
            return Ok("User registered");
        }
    }
}
