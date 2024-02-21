using ApplicationServices.DAO;
using ApplicationServices.Data;
using ApplicationServices.Model;
using ApplicationServices.Models.Flights;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using WSClient.FlightReservation;
using WSClient.ReservationWS;

namespace ApplicationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TokenValidation]
    public class FlightReservationsController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly DataContext _context;
        private readonly IFlightReservationSearchDao reservationSearchDao;

        private ReservationServicesClient reservationServicesClient = new ReservationServicesClient();
        private FlightReservationServicesClient flightReservationServicesClient = new FlightReservationServicesClient();
        public FlightReservationsController(IConfiguration configuration, DataContext context)
        {
            this._context = context;
            DAOFactory factory = new DAOFactory(this._context);
            this.reservationSearchDao = factory.FlightReservationSearchDao;
            this._configuration = configuration;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Reservation>> GetFlightReservations([FromQuery] int? userId)
        {
            IEnumerable<Reservation> reservations;
            if (userId != null)
            {
                reservations = reservationServicesClient.GetReservationsByUserIdAsync((int)userId).Result;
            }
            else
            {
                reservations = reservationServicesClient.GetReservationsAsync().Result;

            }
            if (reservations == null) return NotFound();
            return Ok(reservations);
        }
        [HttpGet("statistics")]
        public async Task<ActionResult<List<Models.Statistics.AirportStatisticsInfoTwo>>> GetReservationsStatistics()
        {
            List<Models.Statistics.AirportStatisticsInfoTwo> result = new List<Models.Statistics.AirportStatisticsInfoTwo>();
            WSClient.FlightReservation.AirportStatisticsInfo[] response = await flightReservationServicesClient.GetAirportReservationStatisticsAsync();
            if (response == null) return NoContent();
            foreach (WSClient.FlightReservation.AirportStatisticsInfo responseItem in response)
            {
                result.Add(new Models.Statistics.AirportStatisticsInfoTwo() { AirportCode = responseItem.AirportCode, AirportCount = responseItem.AirportCount });
            }
            return Ok(result);
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
        public async Task<ActionResult> CreateReservationAsync([FromBody] CreateFlightResevationDto reservation, [FromQuery] int userId)
        {
            int createdReservation;
            IEnumerable<FlightReservationSearch> search = this.reservationSearchDao.FindByItineraryCode(reservation.flightSearchCode).Result;

            foreach (var flightReservationSearch in search)
            {
                Console.WriteLine(flightReservationSearch);
                Reservation reservationNew = new Reservation()
                {
                    UserId = userId,
                    ReservationDate = new DateTime(),
                    ReservationStatus = "confirmed",
                    Price = (decimal)flightReservationSearch.PriceWithFare,
                };
                 createdReservation = await reservationServicesClient.CreateReservationAsync(reservationNew);
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
