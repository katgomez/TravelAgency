using ApplicationServices.Models.Statistics;
using DataServices.Model;

namespace DataServices.DAO;

public interface IFlightReservationDao : IGenericDAO<FlightReservation>
{

    Task<List<AirportStatisticsInfo>> GetAirportReservationStatistics();

}