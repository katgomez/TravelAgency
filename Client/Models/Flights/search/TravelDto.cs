namespace Client.Models.Flights.search
{
    public class TravelDto
    {
        public string iataCode { get; set; }
        public string terminal { get; set; }
        public DateTime at { get; set; }
    }
}
