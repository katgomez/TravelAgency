using Microsoft.EntityFrameworkCore;
using WS.DataServices.Model;

namespace WS.DataServices
{
    public class DataContext : DbContext
    {
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connection = config.GetValue<string>("ConnectionStrings:AgencyTravelMysql");// "server=156.35.98.149;port=3306;database=travelAgency;user=root;Password=travel_root_pass;";
            optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<FlightReservation> FlighReservations { get; set; }
    }
}
