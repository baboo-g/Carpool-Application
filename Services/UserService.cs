using Microsoft.Data.SqlClient.Server;
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

        public async Task<ResponseView<UserProfileDTO>> ProfileService(int id)
        {
            var profileData = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            var avgRating = await _appDbContext.User_Rides.FirstOrDefaultAsync(x => x.User_id == id);

            int rating =0;
            string userType = "";

            if (avgRating != null)
            {
                rating = avgRating.Avg_rating;
                userType = avgRating.User_type;
            }
            if (avgRating == null) {
                rating = 0;
            }

            if (profileData == null)
            {
                return new ResponseView<UserProfileDTO>("Bad Request", "400");
            }

            var response = new UserProfileDTO
            {
                _id = profileData.Id,
                First_name = profileData.First_name,
                Last_name = profileData.Last_name,
                Mobile = profileData.Mobile,
                Rides_completed = profileData.Rides_completed,
               // if (avgRating != null) {
                Avg_rating = rating,
                UserType = userType

                // }
            };
            return new ResponseView<UserProfileDTO>("User Profile Found", "200", response);

        }
            //return new ResponseView<UserDTO>(response);
//            return new ResponseView<UserDTO>("User Profile Found","200", response);
      

    }
}
