using WS.DataServices.Model;

namespace WS.DataServices.DAO.Impl;

public class ReservationDAO: GenericDAO<Reservation>, IReservationDAO
{
    public ReservationDAO(DataContext context) : base(context)
    {
    }
}