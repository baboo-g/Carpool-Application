using Microsoft.EntityFrameworkCore;
using UniRideHubBackend.Data;
using UniRideHubBackend.DTOs;
using UniRideHubBackend.Models;
using UniRideHubBackend.Views;

namespace UniRideHubBackend.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseView<UserDTO>> ProfileService(int id)
        {
            var profileData = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (profileData == null)
            {
                return new ResponseView<UserDTO>("Bad Request", "400");
            }
            var response = new UserDTO
            {
                _id = profileData.Id,
                First_name = profileData.First_name,
                Last_name = profileData.Last_name,
                Mobile = profileData.Mobile,
                Rides_completed = profileData.Rides_completed

            };

            return new ResponseView<UserDTO>("User Profile Found","200", response);
      
        }


    }
}
