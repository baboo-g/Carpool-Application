namespace UniRideHubBackend.DTOs
{
    public class UserRideDTO
    {
        public int User_id { get; set; }
        public int Ride_id { get; set; }
        public string User_type { get; set; }
        public int Avg_rating { get; set; } = 0;

        public bool Is_active { get; set; } = true;
    }
}
