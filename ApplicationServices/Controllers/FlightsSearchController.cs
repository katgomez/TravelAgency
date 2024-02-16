using ApplicationServices.Model.Country;
using ApplicationServices.Models;
using ApplicationServices.Models.Flights;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
        public Flight GetFlight()
        {

            
            return new Flight();
        }
    }
}
