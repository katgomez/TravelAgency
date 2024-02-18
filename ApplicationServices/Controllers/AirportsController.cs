using ApplicationServices.Models.Flights;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Net.Mime;

namespace ApplicationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {

        private IConfiguration _configuration;

        public AirportsController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<AirportResultDto>> GetAirports([FromQuery] string countryCode, [FromQuery] string city)
        {
            var client = new RestClient(_configuration.GetValue<string>("ApplicationSettings:AirportsEndPoint"));

            var request = new RestRequest("", Method.Get);
            request.AddParameter("countryCode", countryCode, ParameterType.QueryString);
            request.AddParameter("city", city, ParameterType.QueryString);

            AirportResultDto result = client.ExecuteAsync<AirportResultDto>(request).Result.Data;
            return Ok(result);
        }
    }
}
