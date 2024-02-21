namespace ApplicationServices.Models.Flights
{
    public class CreateFlightResevationDto
    {
        public int userId { get; set; }
        public string flightSearchCode { get; set; }
        public int adults { get; set; }
    }
}
