using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationServices.Model
{
    public class FlightReservationSearch
    {
        [Key]
        public int Id { get; set; }
        public string FlightId { get; set; }
        public string Airline { get; set; }
        public string DestinationAirport { get; set; }
        public DateTime DestinationDate { get; set; }
        public string DepartureAirport { get; set; }
        public DateTime DepartureDate { get; set; }
        public decimal Price { get; set; }
    }
}
