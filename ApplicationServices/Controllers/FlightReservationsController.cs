using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSClient.FlightReservationWS;
using WSClient.ReservationWS;

namespace ApplicationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightReservationsController : ControllerBase
    {
        private IConfiguration _configuration;
        private FlightReservationServicesClient FlightReservationServicesClient = new FlightReservationServicesClient();
        private ReservationServicesClient reservationServicesClient = new ReservationServicesClient();  
        public FlightReservationsController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<String>>> FlightReservations()
        {
            return Ok();
        }

    }
}
