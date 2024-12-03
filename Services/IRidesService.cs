using Microsoft.AspNetCore.Mvc;
using UniRideHubBackend.Models;
using UniRideHubBackend.Views;

namespace UniRideHubBackend.Services
{
    public interface IRidesService
    {
        //Task<RideDTO> CreateRideAsync([FromForm] RideDTO rideDTO);
        Task<List<Ride>> GetAllRidesAsync();

        Task<Ride> GetRideByIdAsync(int id);

        //Task<RideDTO> UpdateRide(int id);
    }
}
