using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniRideHubBackend.Models
{
    public class Ride
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public string Destination { get; set; }
        public string Mid_routes { get; set; }
        [Required]
        public int Fare { get; set; }
        [Required]
        public int Total_Seats { get; set; }
        [Required]
        public TimeOnly Time { get; set; }
        [Required]
        public DateOnly Date { get; set; }



    }
    
}
