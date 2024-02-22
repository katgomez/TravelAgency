using ApplicationServices.Model;
using Microsoft.EntityFrameworkCore;

namespace ApplicationServices.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
                var connection = config.GetValue<string>("ConnectionStrings:AgencyTravelApplication");
                optionsBuilder.UseSqlite(connection);
            }
        }
        public DbSet<FlightReservationSearch> FlightReservationSearches { get; set; }

    }
}
