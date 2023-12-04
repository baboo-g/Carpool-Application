using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using UniRideHubBackend.Data;
using UniRideHubBackend.DTOs;
using UniRideHubBackend.Models;
using UniRideHubBackend.Views;

namespace UniRideHubBackend.Services
{
    public class UserRideService : IUserRideService
    {
        private readonly AppDbContext _context;

        public UserRideService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<List<UserRideDTO>> GetUserRide(int userid)
        {
            var userRides = await _context.User_Rides
                .Where(ur => ur.User_id == userid) // Filter by userId
                .ToListAsync();
            
            if(userRides.Count == 0)
            {
                return null;
            }
            var userRideDTOs = userRides
                .Select(ur => new UserRideDTO
                {
                    User_id = ur.User_id,
                    Ride_id = ur.Ride_id,
                    User_type = ur.User_type,
                    Avg_rating = ur.Avg_rating,
                    Is_active = ur.Is_Active
                })
                .ToList();

            return userRideDTOs;
        }
    }
}
