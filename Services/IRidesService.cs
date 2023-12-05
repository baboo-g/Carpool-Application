using Microsoft.AspNetCore.Mvc;
using UniRideHubBackend.DTOs;
using UniRideHubBackend.Views;

namespace UniRideHubBackend.Services
{
    public interface IRidesService
    {
        //        Task<ResponseView <List<RideDTO>>> RequestedRidesService(int id);
        Task<RideDTO> CreateRideAsync([FromForm] RideDTO rideDTO);
        Task<List<RideDTO>> GetAllRidesAsync();

        Task<RideDTO> GetRideById(int id);

        Task<RideDTO> UpdateRide(int id);
    }
}
