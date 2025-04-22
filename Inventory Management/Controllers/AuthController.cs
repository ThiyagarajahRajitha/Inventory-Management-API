using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Inventory_Management.Controllers
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

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // Validate credentials (for example purposes, we hard-code the credentials)
            if (login.Username == "admin" && login.Password == "password") // You should authenticate via a DB in a real app
            {
                // Create claims
                var claims = new[]
                {
                new Claim(ClaimTypes.Name, login.Username),
                new Claim(ClaimTypes.Role, "Admin")  // This assigns a role to the user
            };

                // Create signing credentials using a symmetric security key and HMACSHA256 algorithm
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Create the JWT token
                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(1), // Set token expiration time
                    signingCredentials: creds
                );

                // Return the token as a response
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return Unauthorized(); // Invalid credentials
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
