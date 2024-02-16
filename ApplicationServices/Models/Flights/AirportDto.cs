using ApplicationServices.Model.Country;

namespace ApplicationServices.Models.Flights
{
    public class AirportDto
    {

        public string id { get; set; }
        public string name { get; set; }
        public string detailedName { get; set; }
        public string iataCode { get; set; }
        public CountryDto countryDto { get; set; }
        public int travelersScore { get; set; }
    }
}
