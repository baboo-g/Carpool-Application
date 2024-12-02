using Microsoft.AspNetCore.Identity;
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
            var avgRating = await _appDbContext.User_ride.FirstOrDefaultAsync(x => x.User_id == id);

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
	    public async Task<ResponseView<UserAuthDTO>> UserAuthService(UserAuthDTO user)
        {
            if (user == null)
            {
                return new ResponseView<UserAuthDTO>("No User data", "404");
            }
            var authData = await _appDbContext.Users.FirstOrDefaultAsync(x => (x.Mobile == user.Mobile) && (x.Password == user.Password));
            if (authData == null)
            {
                return new ResponseView<UserAuthDTO>("Invalid phone number or password", "400");
            }
            user.Id = authData.Id;
		    return new ResponseView<UserAuthDTO>("Authenticated!", "200", user);
	    }

        public async Task<ResponseView<UserRegisterDTO>> UserRegisterService(UserRegisterDTO user)
        {
            if(user == null)
            {
                return new ResponseView<UserRegisterDTO>("No User data", "404");
            }

            var mobile = await _appDbContext.Users.FirstOrDefaultAsync(x => (x.Mobile == user.Mobile));
            if(mobile != null)
            {
                return new ResponseView<UserRegisterDTO>("User already exists", "400");
            }

			int newId = await _appDbContext.Users.MaxAsync(u => (int?)u.Id) ?? 0;
            newId = newId + 1;

			User newUser = new User();
            newUser.Id = newId;
            newUser.First_name = user.First_name;
            newUser.Last_name = user.Last_name;
            newUser.Mobile = user.Mobile;
            newUser.Password = user.Password;
            newUser.Rides_completed = 0;

            var result = await _appDbContext.AddAsync(newUser);

			await _appDbContext.SaveChangesAsync();


			return new ResponseView<UserRegisterDTO>("User Created Successfully", "200", user);
        }
    }
}
