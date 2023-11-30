namespace UniRideHubBackend.DTOs
{
    public class UserDTO
    {

        public int _id { get; set; }
            public string First_name { get; set; }
            public string Last_name { get; set; }
            public string Mobile { get; set; }
            public string Password { get; set; }
            public int Rides_completed { get; set; }
    }
}
