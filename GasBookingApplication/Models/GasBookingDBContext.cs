using GasBookingApplication.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace GasBookingApp.Models
{
    public class GasBookingDBContext : DbContext
    {
        public GasBookingDBContext(DbContextOptions<GasBookingDBContext> options)
            : base(options)
        {
        }

        public DbSet<user> Users { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Gas> Gases { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add additional model configurations here
        }
    }
}
