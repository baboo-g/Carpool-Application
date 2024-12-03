using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniRideHubBackend.Data;
using UniRideHubBackend.Models;

namespace UniRideHubBackend.Services
{
    public class RidesService : IRidesService
    {
        private readonly AppDbContext _context;

        public RidesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ride>> GetAllRidesAsync()
        {
            return await _context.Rides.ToListAsync();
        }

        public async Task<Ride> GetRideByIdAsync(int id)
        {
            return await _context.Rides.FindAsync(id);
        }
    }
}
