
using ApplicationServices.Data;
using ApplicationServices.Model;

namespace ApplicationServices.DAO.Impl;

public class FlightReservationSearchDao : GenericDAO<FlightReservationSearch>, IFlightReservationSearchDao
{
    public FlightReservationSearchDao(DataContext context) : base(context)
    {
    }

}