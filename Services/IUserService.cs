using UniRideHubBackend.DTOs;
using UniRideHubBackend.Models;
using UniRideHubBackend.Views;

namespace UniRideHubBackend.Services
{
    public interface IUserService
    {
        Task<ResponseView<UserDTO>> ProfileService (int id);
    }
}
