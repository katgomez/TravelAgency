using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightReservationsController : ControllerBase
    {
        private IConfiguration _configuration;
        public FlightReservationsController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> FlightReservations()
        {
            return Ok();
        }

    }
}
