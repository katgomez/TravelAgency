using Microsoft.EntityFrameworkCore;
using DataServices.Model;

namespace DataServices
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<FlightReservation> FlighReservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var connection = config.GetValue<string>("ConnectionStrings:AgencyTravelMysql");// "server=156.35.98.149;port=3306;database=travelAgency;user=root;Password=travel_root_pass;";
                optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
            }
        }
    }
}
