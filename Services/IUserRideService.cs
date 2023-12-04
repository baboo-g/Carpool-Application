using UniRideHubBackend.DTOs;
using UniRideHubBackend.Models;
using UniRideHubBackend.Views;

namespace UniRideHubBackend.Services
{
    public interface IUserRideService
    {
        Task <List<UserRideDTO>> GetUserRide(int userId);
    }
}
