using ApplicationServices.Model.Country;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net.Mime;

namespace ApplicationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private IConfiguration _configuration;
        public CountriesController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [AllowAnonymous]
        public async Task<ActionResult<CountryResultDto>> GetCountries()
        {

            var client = new RestClient(_configuration.GetValue<string>("ApplicationSettings:CountriesEndPoint"));

            var request = new RestRequest("", Method.Get);

            CountryResultDto dto = client.ExecuteAsync<CountryResultDto>(request).Result.Data;
            dto.countries = dto.countries.OrderBy(c => c.name).ToList();
            return Ok(dto);
        }

    }
}
