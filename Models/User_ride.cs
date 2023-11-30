using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniRideHubBackend.Models
{
    public class User_ride
    {
        [Key]
        [ForeignKey("User.Id")]
        public int User_id { get; set; } 

        [ForeignKey("Ride.Id")]
        public int Ride_id { get; set; }
        [Required]

        public string User_type { get; set; }
        public int Avg_rating { get; set; }
    }
}
