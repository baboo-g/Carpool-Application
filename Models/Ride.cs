using System.ComponentModel.DataAnnotations;

namespace UniRideHubBackend.Models
{
    public class Ride
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string source { get; set; }
        [Required]
        public string destination { get; set; }
        public string mid_routes { get; set; }
        [Required]
        public int fare { get; set; }
        [Required]
        public int total_Seats { get; set; }
        [Required]
        public DateTime timestamp { get; set; }
        
    }
    
}
