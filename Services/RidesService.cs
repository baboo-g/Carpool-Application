using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UniRideHubBackend.Data;
using UniRideHubBackend.DTOs;
using UniRideHubBackend.Views;
using UniRideHubBackend.Models;

namespace UniRideHubBackend.Services
{
    public class RidesService : IRidesService
    {
        private readonly AppDbContext _appDbContext;

        public RidesService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<RideDTO> CreateRideAsync(RideDTO rideDTO)
        {
            // Convert the DTO to a Ride object
            Ride ride = new Ride
            {
                Id = rideDTO.Id,
                Source = rideDTO.Source,
                Destination = rideDTO.Destination,
                Mid_routes = rideDTO.Mid_routes,
                Fare = rideDTO.Fare,
                Total_Seats = rideDTO.Total_Seats,
                Timestamp = rideDTO.Timestamp
            };

            _appDbContext.Rides.Add(ride);
            await _appDbContext.SaveChangesAsync();

            // Convert the Ride object back to a DTO and return it
            RideDTO createdRideDTO = new RideDTO
            {
                Id = ride.Id,
                Source = ride.Source,
                Destination = ride.Destination,
                Mid_routes = ride.Mid_routes,
                Fare = ride.Fare,
                Total_Seats = ride.Total_Seats,
                Timestamp = ride.Timestamp
            };

            return createdRideDTO;
        }

        public async Task<List<RideDTO>> GetAllRidesAsync()
        {
            var rides = await _appDbContext.Rides.ToListAsync();
            var rideDTOs = rides.Select(ride => new RideDTO
            {
                Id = ride.Id,
                Source = ride.Source,
                Destination = ride.Destination,
                Mid_routes = ride.Mid_routes,
                Fare = ride.Fare,
                Total_Seats = ride.Total_Seats,
                Timestamp = ride.Timestamp
            }).ToList();

            return rideDTOs;
        }

        // Implement other methods as needed
    }
}
    /*      public async Task<ResponseView<List<RideDTO>>> RequestedRidesService(int id)
          {
              var requestedRidesData = await _appDbContext.RequestedRides.Where(r => r.Id == id).ToListAsync();

              if (requestedRidesData == null)
              {
                  return new ResponseView<List<RideDTO>>("Bad Request", "400");
              }
              List<RideDTO> response = new List<RideDTO>
              {
                  new RideDTO
                  {
                      Id = requestedRidesData.Id,
                      Source = requestedRidesData.Source,
                      Destination = requestedRidesData.Destination,
                      Mid_routes = requestedRidesData.Mid_routes,
                      Total_Seats = requestedRidesData.Total_Seats,
                      Fare = requestedRidesData.Fare,
                      Timestamp = requestedRidesData.Timestamp
                  }
              };
                          *//*
              List response = new List <RideDTO>()
              {
                  Id = requestedRidesData.Id,
                  Source = requestedRidesData.Source,
                  Destination = requestedRidesData.Destination,
                  Mid_routes = requestedRidesData.Mid_routes,
                  Total_Seats = requestedRidesData.Total_Seats,
                  Fare = requestedRidesData.Fare,
                  Timestamp = requestedRidesData.Timestamp
              };*//*
              return new ResponseView<List<RideDTO>>("Requested Rides found", "200", response);

          }*/


