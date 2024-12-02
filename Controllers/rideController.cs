using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniRideHubBackend.Data;
using UniRideHubBackend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniRideHubBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RidesController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Inject AppDbContext directly into the controller
        public RidesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/rides
        [HttpGet]
        public async Task<IActionResult> GetRides()
        {
            try
            {
                // Fetch all rides from the database
                var rides = await _context.Rides.ToListAsync();

                // If no rides found, return NotFound (404)
                if (rides == null || rides.Count == 0)
                {
                    return NotFound("No rides found.");
                }

                // Return the list of rides as a successful response (HTTP 200)
                return Ok(rides);
            }
            catch (System.Exception ex)
            {
                // Return Internal Server Error if any exception occurs
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/rides/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRide(int id)
        {
            try
            {
                // Fetch the specific ride by ID
                var ride = await _context.Rides.FindAsync(id);

                // If no ride found, return NotFound (404)
                if (ride == null)
                {
                    return NotFound($"Ride with ID {id} not found.");
                }

                // Return the specific ride as a successful response (HTTP 200)
                return Ok(ride);
            }
            catch (System.Exception ex)
            {
                // Return Internal Server Error if any exception occurs
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
