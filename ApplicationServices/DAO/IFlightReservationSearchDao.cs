using ApplicationServices.Model;

namespace ApplicationServices.DAO;

public interface IFlightReservationSearchDao : IGenericDAO<FlightReservationSearch>
{
    Task<IEnumerable<FlightReservationSearch>> FindByItineraryCode(string code);
}