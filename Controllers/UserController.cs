using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniRideHubBackend.Data;
using UniRideHubBackend.DTOs;
using UniRideHubBackend.Models;
using UniRideHubBackend.Services;
using UniRideHubBackend.Views;

namespace UniRideHubBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
	//	private readonly AppDbContext _appDBContext;
		private readonly IUserService _userService;
		public UserController(
			//AppDbContext appDBContext, 
			IUserService userService)
		{
		//	_appDBContext = appDBContext;
			_userService = userService;

		}
		/*
		[HttpPost]
		public async Task<IActionResult> AddProduct(User user)
		{
		_appDBContext.Users.Add(user);
			await _appDBContext.SaveChangesAsync();

			return Ok(user);
		}
		
		[HttpGet]
		public async Task<IActionResult> GetAllProducts()
		{
			var users = await _appDBContext.Users.ToListAsync();
			return Ok(users);
		}
		*/
		
		[HttpGet("GetUser/{id}")]
        public async Task<ActionResult<ResponseView<UserDTO>>> GetUserProfile(int id)
        //        public async Task<ActionResult> GetUserProfile(int id)
        {
			try
			{
                //Console.WriteLine("checking");
             //   ResponseView<UserDTO>
					var data = await _userService.ProfileService(id);
               // return new ResponseView<UserDTO>("User Profile Found", "200", response);

                return Ok(data);
			}
			catch (Exception ex)
			{
                return StatusCode(404, "Couldn't find user");
//                return BadRequest(ex.Message);

			}
        }
    }
}
