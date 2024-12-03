using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniRideHubBackend.Models;
using UniRideHubBackend.Services;

namespace UniRideHubBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RidesController : ControllerBase
    {
        private readonly IRidesService _ridesService;

        public RidesController(IRidesService ridesService)
        {
            _ridesService = ridesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRides()
        {
            try
            {
                var rides = await _ridesService.GetAllRidesAsync();

                if (rides == null || rides.Count == 0)
                {
                    return NotFound("No rides found.");
                }

                return Ok(rides);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRide(int id)
        {
            try
            {
                var ride = await _ridesService.GetRideByIdAsync(id);

                if (ride == null)
                {
                    return NotFound($"Ride with ID {id} not found.");
                }

                return Ok(ride);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
