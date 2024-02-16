using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataServices.Model
{
    public class FlightReservation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Reservation")]
        public int ReservationID { get; set; }
        public string FlightId { get; set; }
        public string Airline { get; set; }
        public string DestinationAirport { get; set; }
        public DateTime DestinationDate { get; set; }
        public string DepartureAirport { get; set; }
        public DateTime DepartureDate { get; set; }
        public decimal Price { get; set; }
    }
}
