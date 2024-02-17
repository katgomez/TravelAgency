using ApplicationServices.Model.Country;
using ApplicationServices.Models;
using ApplicationServices.Models.Flights;
using ApplicationServices.Models.Flights.search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace ApplicationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsSearchController : ControllerBase
    {
        private IConfiguration _configuration;

        public FlightsSearchController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet("airports")]
        public async Task<ActionResult<AirportResultDto>> GetAirports([FromQuery]string countryCode, [FromQuery]string city)
        {
            var client = new RestClient(_configuration.GetValue<string>("ApplicationSettings:FlightEndPoint"));

            var request = new RestRequest("airports", Method.Get);
            request.AddParameter("countryCode",countryCode,ParameterType.QueryString);
            request.AddParameter("city", city, ParameterType.QueryString);

            AirportResultDto result = client.ExecuteAsync<AirportResultDto>(request).Result.Data;
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<FlightSearchResultDto>> GetFlights([FromQuery] string originCode, [FromQuery] string destinationCode, 
            [FromQuery] string departureDate, [FromQuery] string returnDate,
            [FromQuery] int adults, [FromQuery] string fareType)
        {
            var client = new RestClient(_configuration.GetValue<string>("ApplicationSettings:FlightEndPoint"));


            var request = new RestRequest("flight-offers", Method.Get);
            request.AddParameter("originLocationCode", originCode, ParameterType.QueryString);
            request.AddParameter("destinationLocationCode", destinationCode, ParameterType.QueryString);
            request.AddParameter("departureDate", departureDate, ParameterType.QueryString);
            request.AddParameter("returnDate", returnDate, ParameterType.QueryString);
            request.AddParameter("adults", adults, ParameterType.QueryString);
            request.AddParameter("max", 5, ParameterType.QueryString);
            request.AddParameter("fareType", fareType, ParameterType.QueryString);

            FlightSearchResultDto result = JsonConvert.DeserializeObject <FlightSearchResultDto>(client.ExecuteAsync<FlightSearchResultDto>(request).Result.Content);

            return Ok(result);
        }
    }
}
