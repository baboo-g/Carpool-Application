using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UniRideHubBackend.Data;
using UniRideHubBackend.DTOs;
using UniRideHubBackend.Views;

namespace UniRideHubBackend.Services
{
    public class RidesService : IRidesService
    {
        private readonly AppDbContext _appDbContext;

        public RidesService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
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

    }
}
