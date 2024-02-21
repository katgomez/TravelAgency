namespace ApplicationServices.Models.Flights.search
{
    public class FlightSearchResultDto
    {
        public int numberResults { get; set; }

        public List<FlightResultDto> flights { get; set; }
    }
}
