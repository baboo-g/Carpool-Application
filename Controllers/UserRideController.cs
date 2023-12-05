using Microsoft.AspNetCore.Authorization;
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
	public class UserRideController : ControllerBase
    {
        private readonly IUserRideService _userRideService;

        public UserRideController(IUserRideService userRideService)
        {
            _userRideService = userRideService;
        }

        [HttpGet("GetUserRide/{id}")]
        public async Task<IActionResult> GetUserRideById(int id)
        {
            var userride = await _userRideService.GetUserRide(id);
            return Ok(userride);
        }

        [HttpPost("AddUserRide")]
        public async Task<IActionResult> AddUserRide([FromForm] UserRideDTO userride)
        {
            UserRideDTO createdUserRideDTO = await _userRideService.AddUserRide(userride);

            return Ok(createdUserRideDTO);
        }
    }
}
