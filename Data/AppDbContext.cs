using Microsoft.EntityFrameworkCore;
using UniRideHubBackend.Models;

namespace UniRideHubBackend.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options) { }
		public DbSet<User> Users { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<User_ride> User_Rides { get; set; }
//        public DbSet<RequestedRides> RequestedRides { get; set; }

    }
}

