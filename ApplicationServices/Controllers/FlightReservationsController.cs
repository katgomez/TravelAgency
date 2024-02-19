using ApplicationServices.DAO;
using ApplicationServices.Data;
using ApplicationServices.Model;
using ApplicationServices.Models.Flights;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using WSClient.ReservationWS;

namespace ApplicationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightReservationsController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly DataContext _context;
        private readonly IFlightReservationSearchDao dao;

        private ReservationServicesClient reservationServicesClient = new ReservationServicesClient();
        public FlightReservationsController(IConfiguration configuration, DataContext context)
        {
            this._context = context;
            DAOFactory factory = new DAOFactory(this._context);
            this.dao = factory.FlightReservationSearchDao;
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
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult CreateReservation( [FromBody]CreateFlightResevationDto reservation)
        {
            IEnumerable<FlightReservationSearch> search =  this.dao.FindByItineraryCode(reservation.flightSearchCode).Result;
           
            foreach(var flightReservationSearch in search)
            {
                
            }
            return Ok();
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
