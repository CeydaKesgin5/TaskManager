using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TaskManagerClass.DataAccess.Concrete;

namespace TaskManagerClass.Controllers
{
    [ApiController]
    [Route("api/controller1")]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private readonly TaskManagerContext _context;
        private static List<UserModel> Users = new List<UserModel>();

        public LoginController(IConfiguration config, TaskManagerContext context)
        {
            _config = config;
            _context = context;

        }



        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserModel newUser)
        {
            if (newUser != null)
            {
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return Ok("User registered successfully.");
            }
            return BadRequest("Invalid user data.");
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserModel login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel AuthenticateUser(UserModel login)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);
            return user;
        }


     

    }
}
