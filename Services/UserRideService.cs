using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using UniRideHubBackend.Data;
using UniRideHubBackend.DTOs;
using UniRideHubBackend.Models;
using UniRideHubBackend.Views;
using Microsoft.AspNetCore.Mvc;

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
            var userRides = await _context.User_ride
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

        public async Task<UserRideDTO> AddUserRide([FromForm] UserRideDTO userRideDTO)
        {
            User_ride userride = new User_ride
            {
                User_id = userRideDTO.User_id,
                Ride_id = userRideDTO.Ride_id,
                User_type = "rider",
                Avg_rating = 0,
                Is_Active = true
            };

            _context.User_ride.Add(userride);
            await _context.SaveChangesAsync();

            UserRideDTO createdRideDTO = new UserRideDTO
            {
                User_id = userride.User_id,
                Ride_id = userride.Ride_id,
                User_type = userride.User_type,
                Avg_rating = userride.Avg_rating,
                Is_active = userride.Is_Active
            };
            return createdRideDTO;
        }

    }
}
