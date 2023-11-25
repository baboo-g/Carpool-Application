using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using UniRideHubBackend.Data;
using UniRideHubBackend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniRideHubBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {

        private readonly AppDbContext _appDBContext;
        public RideController(AppDbContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

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
