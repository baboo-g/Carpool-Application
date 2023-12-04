using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace UniRideHubBackend.Models
{
    public class Ride
    {
        [Required]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
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
       
        public string Time { get; set; }
      
        [Required]
        
        public string Date { get; set; }
        [Required]
        public string MapImageFileName { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public IFormFile file { get; set; }



    }

}
