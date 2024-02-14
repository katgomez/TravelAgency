using Microsoft.EntityFrameworkCore;
using WS.DataServices.Model;

namespace WS.DataServices
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=travelagency.db");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<FlightReservation> FlighReservations { get; set; }
    }
}
