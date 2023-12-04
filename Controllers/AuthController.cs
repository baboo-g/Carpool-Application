using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Humanizer.Localisation.TimeToClockNotation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UniRideHubBackend.DTOs;
using UniRideHubBackend.Services;
using UniRideHubBackend.Views;

namespace UniRideHubBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly IConfiguration _configuration;


		public AuthController(IUserService userService, IConfiguration configuration)
		{
			_userService = userService;
			_configuration = configuration;
		}

		private string CreateToken(UserAuthDTO user)
		{
			List<Claim> claims = new List<Claim>()
			{
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
			};
			//to be implemented: 25:34
			var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
				_configuration.GetSection("JWT:Token").Value));

			var creds =  new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var token = new JwtSecurityToken(
				claims: claims,
				expires: DateTime.Now.AddHours(2),
				signingCredentials: creds);

			var jwt = new JwtSecurityTokenHandler().WriteToken(token);
			
			return jwt;
		}

		[AllowAnonymous]
		[HttpPost("authenticate")]
		public async Task<IActionResult> Authenticate(UserAuthDTO user)
		{
			var response = await _userService.UserAuthService(user);
			if (response.StatusCode == "200")
			{
				string token = CreateToken(user);
				int id = response.ResponseData.Id;
				Tuple<string, int> res = new Tuple<string, int>(token, id);
				return Ok(res);
			}
			else
			{
				return BadRequest(response.Message);
			}
		}

		[AllowAnonymous]
		[HttpPost("register")]
		public async Task<IActionResult> Register(UserRegisterDTO user)
		{
			var response = await _userService.UserRegisterService(user);
			if (response.StatusCode == "200")
			{
				return Ok(response.ResponseData);
			}
			else
			{
				return BadRequest(response.Message);
			}
		}


	}
}
