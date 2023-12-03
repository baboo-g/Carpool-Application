using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UniRideHubBackend.DTOs
{
    public class RideDTO
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Mid_routes { get; set; }
        public int Fare { get; set; }
        public int Total_Seats { get; set; }
        /* public DateTime Timestamp { get; set; }*/
      
        public string Time { get; set; }
       
        public string Date { get; set; }
        public string MapImageFileName { get; set; }

        [NotMapped]
        public IFormFile file { get; set; }
    }
}
