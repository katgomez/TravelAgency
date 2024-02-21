using System.ComponentModel.DataAnnotations;

namespace ApplicationServices.Model
{
    public class FlightReservationSearch
    {

        [Key]
        public int Id { get; set; }

        public string SearchId { get; set; }
        public string CodeOfItinerary { get; set; }
        public string FlightId { get; set; }
        public string Airline { get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string DepartureAirport { get; set; }
        public DateTime DepartureDate { get; set; }
        public int numberOfStops { get; set; }
        public double Duration { get; set; }
        public double Price { get; set; }

        public double PriceWithFare { get; set; }
    }
}
