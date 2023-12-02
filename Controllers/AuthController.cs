using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniRideHubBackend.DTOs;
using UniRideHubBackend.Services;

namespace UniRideHubBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IUserService _userService;

		public AuthController(IUserService userService)
		{
			_userService = userService;
		}

		[AllowAnonymous]
		[HttpPost("authenticate")]
		public async Task<IActionResult> Authenticate(UserAuthDTO user)
		{
			var response = await _userService.UserAuthService(user);
			if (response.StatusCode == "200")
			{
				return Ok(response);
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
