using ApplicationServices.DAO;
using ApplicationServices.Data;
using ApplicationServices.Model;
using ApplicationServices.Models.Fares;
using ApplicationServices.Models.Flights.search;
using ApplicationServices.Models.Statistics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Mime;
using WSClient.FlightReservation;

namespace ApplicationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsSearchController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly IFlightReservationSearchDao reservationSearchDao;
        private IConfiguration _configuration;

        public FlightsSearchController(IConfiguration configuration, DataContext dbContext)
        {
            this._context = dbContext;
            DAOFactory factory = new DAOFactory(this._context);
            this.reservationSearchDao = factory.FlightReservationSearchDao;
            this._configuration = configuration;
        }

        [HttpGet("statistics")]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<IEnumerable<AirportStatisticsInfo>> GetAirportReservationSearchStatistics()
        {
            List<AirportStatisticsInfo> statistics = this.reservationSearchDao.GetAirportReservationSearchStatistics().Result;
            if (statistics == null) return NoContent();
            return Ok(statistics);
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<FlightSearchResultDto>> GetFlights([FromQuery] string originCode, [FromQuery] string destinationCode,
            [FromQuery] string departureDate, [FromQuery] string? returnDate,
            [FromQuery] int adults, [FromQuery] string fareType)
        {
            var client = new RestClient(_configuration.GetValue<string>("ApplicationSettings:FlightEndPoint"));

            var request = new RestRequest("", Method.Get);
            request.AddParameter("originLocationCode", originCode, ParameterType.QueryString);
            request.AddParameter("destinationLocationCode", destinationCode, ParameterType.QueryString);
            request.AddParameter("departureDate", departureDate, ParameterType.QueryString);
            if (returnDate != null)
            {
                request.AddParameter("returnDate", returnDate, ParameterType.QueryString);
            }
            request.AddParameter("adults", adults, ParameterType.QueryString);
            request.AddParameter("max", 5, ParameterType.QueryString);

            FareType fare;

            if (!Enum.TryParse(fareType, out fare))
            {
                return BadRequest();
            }
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            FlightSearchResultDto result = JsonConvert.DeserializeObject<FlightSearchResultDto>(client.ExecuteAsync<FlightSearchResultDto>(request).Result.Content, settings);

            if (result == null || result.numberResults == 0)
            {
                return NoContent();
            }
            string searchId = Guid.NewGuid().ToString();
            //Se calcula la tarifa seleccionada
            foreach (FlightResultDto resultDto in result.flights)
            {
                resultDto.priceWithFare = FareTypeExtensions.PriceWithFare(fare, resultDto.price);



                string uuid = Guid.NewGuid().ToString();
                resultDto.flightCode = uuid;
                foreach (FlightItineraryDto itinerary in resultDto.departureDayItineraries)
                {
                    if (itinerary.itinerary.Count > 0)
                    {


                        SegmentDto segmento = itinerary.itinerary[0];


                        FlightReservationSearch reservationTemp = new FlightReservationSearch();
                        reservationTemp.CodeOfItinerary = uuid;
                        reservationTemp.DepartureAirport = segmento.departure.iataCode;
                        reservationTemp.DepartureDate = segmento.departure.at;
                        reservationTemp.ArrivalAirport = segmento.arrival.iataCode;
                        reservationTemp.ArrivalDate = segmento.arrival.at;
                        reservationTemp.Price = resultDto.price;
                        reservationTemp.PriceWithFare = resultDto.priceWithFare;
                        reservationTemp.Duration = segmento.durationMinutes;
                        reservationTemp.Airline = segmento.carrierCode;
                        reservationTemp.FlightId = resultDto.id;
                        reservationTemp.SearchId = searchId;
                        _context.FlightReservationSearches.Add(reservationTemp);
                        await _context.SaveChangesAsync();

                    }
                }

            }



            return Ok(result);
        }
    }
}
