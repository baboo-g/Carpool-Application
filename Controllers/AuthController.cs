using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UniRideHubBackend.DTOs;
using UniRideHubBackend.Data;
using UniRideHubBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace UniRideHubBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        // Constructor injecting AppDbContext and IConfiguration
        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // Method to create JWT Token
        private string CreateToken(UserAuthDTO user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.MobilePhone, user.Mobile)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("Jwt:Key").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        // Authenticate method to validate user credentials and generate token
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserAuthDTO user)
        {
            // Query the database for the user
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Mobile == user.Mobile && u.Password == user.Password);

            if (existingUser == null)
            {
                return BadRequest("Invalid username or password");
            }

            // Create token for the authenticated user
            var token = CreateToken(new UserAuthDTO
            {
                Id = existingUser.Id,
                Mobile = existingUser.Mobile
            });

            // Return the JWT token and user ID
            return Ok(new { Token = token, UserId = existingUser.Id });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO user)
        {
            if (await _context.Users.AnyAsync(u => u.Mobile == user.Mobile))
            {
                return BadRequest("Username already exists");
            }
            var newUser = new User
            {
                First_name = user.First_name,
                Last_name = user.Last_name,
                Mobile = user.Mobile,
                Password = user.Password 
            };


            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
