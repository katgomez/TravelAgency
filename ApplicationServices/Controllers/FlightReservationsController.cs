﻿using ApplicationServices.DAO;
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

        private ReservationServicesClient reservationServicesClient;
        private FlightReservationServicesClient flightReservationServicesClient;
        public FlightReservationsController(IConfiguration configuration, DataContext context)
        {
            this._context = context;
            DAOFactory factory = new DAOFactory(this._context);
            this.reservationSearchDao = factory.FlightReservationSearchDao;
            this._configuration = configuration;

            reservationServicesClient = new ReservationServicesClient(ReservationServicesClient.
            EndpointConfiguration.BasicHttpBinding_IReservationServices, _configuration.GetValue<string>("ApplicationSettings:AppDataReservationServiceEndPoint"));
            
            flightReservationServicesClient = new FlightReservationServicesClient(FlightReservationServicesClient.
          EndpointConfiguration.BasicHttpBinding_IFlightReservationServices, _configuration.GetValue<string>("ApplicationSettings:AppDataFlightServiceEndPoint"));
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
        public async Task<ActionResult> CreateReservationAsync([FromBody] CreateFlightResevationDto reservation)
        {
            int createdReservation=0;
            IEnumerable<FlightReservationSearch> search = this.reservationSearchDao.FindByItineraryCode(reservation.flightSearchCode).Result;

            foreach (var flightReservationSearch in search)
            {
                Console.WriteLine(flightReservationSearch);

                
                Reservation reservationNew = new Reservation()
                {
                    UserId = reservation.userId,
                    NumberOfClients = reservation.adults,
                    ReservationDate = DateTime.Now,
                    ReservationStatus = "Confirmed",
                    Price = (decimal)flightReservationSearch.PriceWithFare,
                };
                createdReservation = await reservationServicesClient.CreateReservationAsync(reservationNew);

                //WSClient.FlightReservation.FlightReservation flightReservation = new WSClient.FlightReservation.FlightReservation
                //{
                //    ReservationID = createdReservation,
                //    Airline = flightReservationSearch.Airline,
                //    ArrivalAirport = flightReservationSearch.ArrivalAirport,
                //    ArrivalDate = flightReservationSearch.ArrivalDate,
                //    CodeOfItinerary = flightReservationSearch.CodeOfItinerary,
                //    DepartureAirport = flightReservationSearch.DepartureAirport,
                //    DepartureDate = flightReservationSearch.DepartureDate,
                //    Duration = flightReservationSearch.Duration,
                //    FlightId = flightReservationSearch.FlightId,
                //    numberOfStops = flightReservationSearch.numberOfStops,
                //    Price = flightReservationSearch.Price,
                //};
                //await flightReservationServicesClient.CreateFlightAsync(flightReservation);

            }
            return Ok(createdReservation);
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
