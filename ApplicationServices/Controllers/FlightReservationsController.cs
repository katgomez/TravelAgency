using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSClient.ReservationWS;

namespace ApplicationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightReservationsController : ControllerBase
    {
        private IConfiguration _configuration;
        private ReservationServicesClient reservationServicesClient = new ReservationServicesClient();  
        public FlightReservationsController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Reservation>> GetFlightReservations()
        {
            return Ok(reservationServicesClient.GetReservationsAsync());
        }

        [HttpGet]
        public ActionResult<IEnumerable<Reservation>> GetFlightReservation(int reservationId)
        {
            return Ok(reservationServicesClient.GetReservationAsync(reservationId));
        }

    }
}
