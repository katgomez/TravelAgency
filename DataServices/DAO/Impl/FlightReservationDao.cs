using DataServices.Model;

namespace DataServices.DAO.Impl;

public class FlightReservationDao : GenericDAO<FlightReservation>, IFlightReservationDao
{
    public FlightReservationDao(DataContext context) : base(context)
    {
    }
}