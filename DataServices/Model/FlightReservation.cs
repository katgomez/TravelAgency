using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataServices.Model
{
    public class FlightReservation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Reservation")]
        public int ReservationID { get; set; }
        public int CodeOfItinerary { get; set; }
        public string FlightId { get; set; }
        public string Airline { get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string DepartureAirport { get; set; }
        public DateTime DepartureDate { get; set; }
        public int numberOfStops { get; set; }
        public string Duration { get; set; }
        public decimal Price { get; set; }
    }
}
