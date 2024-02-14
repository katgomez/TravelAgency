using System.ServiceModel;
using WS.DataServices.Model;

namespace WS.DataServices.Service;

public class ReservationServices: IReservationServices
{
    public Reservation[] GetReservations()
    {
        using (DAOFactory factory = new DAOFactory())
        {
            return factory.ReservationDao.All().ToArray();
        }
    }

    public Reservation GetReservation(int id)
    {
        using (DAOFactory factory = new DAOFactory())
        {
            Reservation[] reservations = factory.ReservationDao.All().ToArray();
            return reservations.First(p => p.Id == id);
        }
    }

    public void CreateReservation(Reservation reservation)
    {
        using (DAOFactory factory = new DAOFactory())
        {
            Reservation checkedReservation = factory.ReservationDao.All().FirstOrDefault(p => p.Id == reservation.Id);
            if (checkedReservation != null) 
                throw new FaultException(new FaultReason("User already exists!!!"), new FaultCode("400"), "");
            factory.ReservationDao.Add(reservation);
        }
    }

    public void UpdateReservation(Reservation reservation)
    {
        using (DAOFactory factory = new DAOFactory())
        {
            Reservation checkedReservation = factory.ReservationDao.All().FirstOrDefault(p => p.Id == reservation.Id);
            if (checkedReservation == null)
                throw new FaultException(new FaultReason("Product not found!!!"), new FaultCode("404"), "");
            factory.ReservationDao.Update(reservation);
        }
    }
}