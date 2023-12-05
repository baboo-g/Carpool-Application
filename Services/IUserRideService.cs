using Microsoft.AspNetCore.Mvc;
using UniRideHubBackend.DTOs;
using UniRideHubBackend.Models;
using UniRideHubBackend.Views;

namespace UniRideHubBackend.Services
{
    public interface IUserRideService
    {
        Task <List<UserRideDTO>> GetUserRide(int userId);
        Task<UserRideDTO> AddUserRide([FromForm] UserRideDTO userRideDTO);
    }
}
