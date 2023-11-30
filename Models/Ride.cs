using System.ComponentModel.DataAnnotations;

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
        public DateTime timestamp { get; set; }
        
    }
    
}
