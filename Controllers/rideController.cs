using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using UniRideHubBackend.Data;
using UniRideHubBackend.Models;
using UniRideHubBackend.Services;
using UniRideHubBackend.DTOs;
using UniRideHubBackend.Views;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniRideHubBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[Authorize]
	public class RideController : ControllerBase
    {
        private readonly IRidesService _ridesService;

        public RideController(IRidesService ridesService)
        {
            _ridesService = ridesService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] RideDTO rideDTO)
        {
            RideDTO createdRideDTO = await _ridesService.CreateRideAsync(rideDTO);

            return Ok(createdRideDTO);
        }

        [HttpGet("Getride")]
        public async Task<IActionResult> GetAllProducts()
        {
            var riders = await _ridesService.GetAllRidesAsync();
            return Ok(riders);
        }

        [HttpGet("Getride/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var ride = await _ridesService.GetRideById(id);
            return Ok(ride);
        }

        [HttpPut("UpdateRideSeats")]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var ride = await _ridesService.UpdateRide(id);
            return Ok(ride);
        }
    }
}
