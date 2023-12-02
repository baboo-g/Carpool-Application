using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace UniRideHubBackend.Models
{
	public class User
	{
		public int Id { get; set; }
		[Required]
		public string First_name { get; set; }
		[Required]
		public string Last_name { get; set; }
		[Required]
		public string Mobile { get; set; }
		[Required]
		public string Password { get; set; }
		public int Rides_completed { get; set; }
//		public int Avg_rating { get; set; }
    }
}
