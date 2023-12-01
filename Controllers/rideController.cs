using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using UniRideHubBackend.Data;
using UniRideHubBackend.Models;
using UniRideHubBackend.Services;
using UniRideHubBackend.DTOs;
using UniRideHubBackend.Views;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniRideHubBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        private readonly IRidesService _ridesService;

        private readonly AppDbContext _appDBContext;
        public RideController(IRidesService ridesService,
         AppDbContext appDBContext)
        {
            _ridesService = ridesService;
            _appDBContext = appDBContext;
        }
/*        [HttpGet("GetAll")]
        public async Task<ActionResult<ResponseView<List <UserDTO>>>> GetRequestedRides(int id)
        {
            try
            {
 
                var data = await _ridesService.RequestedRidesService(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(404, "Couldn't find rides");

            }
        }*/

        [HttpPost]
        public async Task<IActionResult> AddProduct(Ride ride)
        {
            _appDBContext.Rides.Add(ride);
            await _appDBContext.SaveChangesAsync();

            return Ok(ride);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var riders = await _appDBContext.Rides.ToListAsync();
            return Ok(riders);
        }
    }
}
