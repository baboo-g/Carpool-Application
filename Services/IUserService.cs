using UniRideHubBackend.DTOs;
using UniRideHubBackend.Models;
using UniRideHubBackend.Views;

namespace UniRideHubBackend.Services
{
    public interface IUserService
    {
        Task<ResponseView<UserProfileDTO>> ProfileService (int id);
        Task<ResponseView<UserAuthDTO>> UserAuthService (UserAuthDTO user);
		Task<ResponseView<UserRegisterDTO>> UserRegisterService(UserRegisterDTO user);
	}
}
