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
        public TimeOnly Time { get; set; }
      
        public DateOnly Date { get; set; }
    }
}
