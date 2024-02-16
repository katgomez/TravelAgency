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
            var reservations = reservationServicesClient.GetReservationsAsync();
            if (reservations == null) return NotFound();
            return Ok(reservations);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Reservation>> GetReservationsByUserId([FromQuery] int userId)
        {

            var reservations = reservationServicesClient.GetReservationsByUserIdAsync(userId);
            if (reservations == null) return NotFound();
            return Ok(reservations);
        }

        [HttpGet("{reservationId}")]
        public ActionResult<IEnumerable<Reservation>> GetFlightReservation(int reservationId)
        {
            var reservations = reservationServicesClient.GetReservationByIdAsync(reservationId);
            if (reservations == null) return NotFound();
            return Ok(reservations);
        }


        [HttpPost]
        public ActionResult CreateReservation([FromBody] Reservation reservation)
        {
            var createdReservation = reservationServicesClient.CreateReservationAsync(reservation);
            if (createdReservation == null) return StatusCode(500, "Failed to create reservation");
            return CreatedAtAction(nameof(Reservation), new { id = createdReservation.Id }, createdReservation);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateReservation(int id, [FromBody] Reservation updatedReservation)
        {
            if (id != updatedReservation.Id) return NotFound();
            else
            {
                var updated = reservationServicesClient.UpdateReservationAsync(updatedReservation);
                if (updated == null) return NotFound();
                return NoContent();
            }
        
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteReservation(int id)
        {
            var deleted = reservationServicesClient.DeleteReservationAsync(id);
            if (deleted == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
