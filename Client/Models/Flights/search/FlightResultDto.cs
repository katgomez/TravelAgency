namespace Client.Models.Flights.search
{
    public class FlightResultDto
    {
        public string id { get; set; }

        public List<FlightItineraryDto> departureDayItineraries { get; set; }
        public List<FlightItineraryDto> returnDayItineraries { get; set; }

        public double price { get; set; }
        public string currency { get; set; }

        public double priceWithFare { get; set; }
    }
}
