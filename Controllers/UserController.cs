using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniRideHubBackend.Data;
using UniRideHubBackend.Models;

namespace UniRideHubBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly AppDbContext _appDBContext;
		public UserController(AppDbContext appDBContext)
		{
			_appDBContext = appDBContext;
		}

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
	}
}
