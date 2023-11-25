namespace UniRideHubBackend.Models
{
	public class User
	{
		public int id { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string mobile { get; set; }
		public string password { get; set; }
		public int rides_completed { get; set; }
	}
}
