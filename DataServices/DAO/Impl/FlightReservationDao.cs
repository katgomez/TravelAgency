using WS.DataServices.Model;

namespace WS.DataServices.DAO.Impl;

public class FlightReservationDao: GenericDAO<FlightReservation>, IFlightReservationDao
{
    public FlightReservationDao(DataContext context) : base(context)
    {
    }
}