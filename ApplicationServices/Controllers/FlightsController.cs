using ApplicationServices.Model.Country;
using ApplicationServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace ApplicationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private IConfiguration _configuration;
        public FlightsController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        public Flight GetFlight()
        {

            
            return new Flight();
        }
    }
}
