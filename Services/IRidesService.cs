using UniRideHubBackend.DTOs;
using UniRideHubBackend.Views;

namespace UniRideHubBackend.Services
{
    public interface IRidesService
    {
        //        Task<ResponseView <List<RideDTO>>> RequestedRidesService(int id);
        Task<RideDTO> CreateRideAsync(RideDTO rideDTO);
        Task<List<RideDTO>> GetAllRidesAsync();
    }
}
