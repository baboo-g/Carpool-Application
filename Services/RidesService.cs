using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UniRideHubBackend.Data;
using UniRideHubBackend.DTOs;
using UniRideHubBackend.Views;
using UniRideHubBackend.Models;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace UniRideHubBackend.Services
{
    public class RidesService : IRidesService
    {
        private readonly AppDbContext _appDbContext;

        public RidesService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<RideDTO> CreateRideAsync([FromForm] RideDTO rideDTO)
        {
            string path = Path.Combine(@"F:\Uni\7th Semester\IPT\project\UniRideHub\src\assets\mapImage", rideDTO.MapImageFileName);
            using(Stream stream = new FileStream(path,FileMode.Create))
            {
                rideDTO.file.CopyTo(stream);
            }
           
            // Convert the DTO to a Ride object
            Ride ride = new Ride
            {
                Id = rideDTO.Id,
                UserId = rideDTO.UserId,
                Source = rideDTO.Source,
                Destination = rideDTO.Destination,
                Mid_routes = rideDTO.Mid_routes,
                Fare = rideDTO.Fare,
                Total_Seats = rideDTO.Total_Seats,
                Time = rideDTO.Time,
                Date = rideDTO.Date,
                MapImageFileName = rideDTO.MapImageFileName
            };

            _appDbContext.Rides.Add(ride);
            await _appDbContext.SaveChangesAsync();

            // Convert the Ride object back to a DTO and return it
            RideDTO createdRideDTO = new RideDTO
            {
                Id = ride.Id,
                UserId = ride.UserId,
                Source = ride.Source,
                Destination = ride.Destination,
                Mid_routes = ride.Mid_routes,
                Fare = ride.Fare,
                Total_Seats = ride.Total_Seats,
                Time = ride.Time,
                Date = ride.Date,
                MapImageFileName = ride.MapImageFileName
            };

            return createdRideDTO;
        }
       
        public async Task<List<RideDTO>> GetAllRidesAsync()
        {
            var rides = await _appDbContext.Rides.ToListAsync();
            var rideDTOs = rides.Select(ride => new RideDTO
            {
                Id = ride.Id,
                UserId =ride.UserId,
                Source = ride.Source,
                Destination = ride.Destination,
                Mid_routes = ride.Mid_routes,
                Fare = ride.Fare,
                Total_Seats = ride.Total_Seats,
                Time = ride.Time,
                Date = ride.Date,
                MapImageFileName = ride.MapImageFileName
                /*Timestamp = ride.Timestamp*/
            }).ToList();

            return rideDTOs;
        }

        // Implement other methods as needed
        public async Task<RideDTO> GetRideById(int id)
        {
            var ride = await _appDbContext.Rides.FirstOrDefaultAsync(x => x.Id == id);
            if (ride == null)
            {
                // If the ride with the specified ID doesn't exist, return null or throw an exception as needed
                return null; // or throw new Exception("Ride not found");
            }

            // Convert the Ride object to a DTO
            RideDTO rideDTO = new RideDTO
            {
                Id = ride.Id,
                UserId = ride.UserId,
                Source = ride.Source,
                Destination = ride.Destination,
                Mid_routes = ride.Mid_routes,
                Fare = ride.Fare,
                Total_Seats = ride.Total_Seats,
                Time = ride.Time,
                Date = ride.Date,
                MapImageFileName = ride.MapImageFileName
                /*Timestamp = ride.Timestamp*/
            };

            return rideDTO;
        }

        public async Task<RideDTO> UpdateRide(int id)
        {
            var ride = await _appDbContext.Rides.FirstOrDefaultAsync(x => x.Id == id);
            if (ride == null)
            {
                return null;
            }
            ride.Total_Seats -= 1;
            RideDTO createdRideDTO = new RideDTO
            {
                Id = ride.Id,
                UserId = ride.UserId,
                Source = ride.Source,
                Destination = ride.Destination,
                Mid_routes = ride.Mid_routes,
                Fare = ride.Fare,
                Total_Seats = ride.Total_Seats,
                Time = ride.Time,
                Date = ride.Date,
                MapImageFileName = ride.MapImageFileName
            };
            _appDbContext.Rides.Update(ride);
            await _appDbContext.SaveChangesAsync();
            

            return createdRideDTO;
        }

    }
}
  


