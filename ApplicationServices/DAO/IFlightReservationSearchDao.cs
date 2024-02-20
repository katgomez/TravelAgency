using ApplicationServices.Model;
using ApplicationServices.Models;

namespace ApplicationServices.DAO;

public interface IFlightReservationSearchDao : IGenericDAO<FlightReservationSearch>
{
    Task<IEnumerable<FlightReservationSearch>> FindByItineraryCode(string code);

    Task<List<AirportStatisticsInfo>> GetReservationStatistics();

}