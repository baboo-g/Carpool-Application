using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniRideHubBackend.Data;
using UniRideHubBackend.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace UniRideHubBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRidesController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Constructor to inject AppDbContext
        public UserRidesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserRides
        [HttpGet]
        public async Task<IActionResult> GetUserRides()
        {
            try
            {
                // Fetch all user rides from the database
                var userRides = await _context.User_ride.ToListAsync();

                // If no records are found
                if (userRides == null || !userRides.Any())
                {
                    return NotFound("No user rides found.");
                }

                // Return the list of user rides
                return Ok(userRides);
            }
            catch (System.Exception ex)
            {
                // Return Internal Server Error if any exception occurs
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/UserRides/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserRide(int id)
        {
            try
            {
                // Fetch a single user ride by id
                var userRide = await _context.User_ride
                    .FirstOrDefaultAsync(ur => ur.Id == id);

                // If the user ride does not exist
                if (userRide == null)
                {
                    return NotFound($"User ride with ID {id} not found.");
                }

                // Return the user ride
                return Ok(userRide);
            }
            catch (System.Exception ex)
            {
                // Return Internal Server Error if any exception occurs
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/UserRides
        [HttpPost]
        public async Task<IActionResult> CreateUserRide([FromBody] User_ride userRide)
        {
            try
            {
                if (userRide == null)
                {
                    return BadRequest("Invalid user ride data.");
                }

                // Add the new user ride to the context
                _context.User_ride.Add(userRide);

                // Save changes to the database
                await _context.SaveChangesAsync();

                // Return the created user ride with a 201 Created response
                return CreatedAtAction(nameof(GetUserRide), new { id = userRide.Id }, userRide);
            }
            catch (System.Exception ex)
            {
                // Return Internal Server Error if any exception occurs
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
