using System.ServiceModel;
using DataServices.Model;

namespace DataServices.Service;

public class ReservationServices : IReservationServices
{
    private readonly DAOFactory _daoFactory;
    public ReservationServices(DAOFactory daoFactory)
    {
        _daoFactory = daoFactory ?? new DAOFactory();
    }
    public Reservation[] GetReservations()
    {
        using (DAOFactory factory = _daoFactory)
        {
            return factory.ReservationDao.All().ToArray();
        }
    }

    public Reservation[] GetReservationsByUserId(int id)
    {
        using (DAOFactory factory = _daoFactory)
        {
            return factory.ReservationDao.All().Where(reservation => reservation.UserId == id).ToArray();
        }
    }

    public Reservation GetReservationById(int id)
    {
        using (DAOFactory factory = _daoFactory)
        {
            Reservation[] reservations = factory.ReservationDao.All().ToArray();
            return reservations.First(p => p.Id == id);
        }
    }

    public void CreateReservation(Reservation reservation)
    {
        using (DAOFactory factory = _daoFactory)
        {
            Reservation checkedReservation = factory.ReservationDao.All().FirstOrDefault(p => p.Id == reservation.Id);
            if (checkedReservation != null)
                throw new FaultException(new FaultReason("Reservation already exists!!!"), new FaultCode("400"), "");
            factory.ReservationDao.Add(reservation);
        }
    }

    public void UpdateReservation(Reservation reservation)
    {
        using (DAOFactory factory = _daoFactory)
        {
            Reservation checkedReservation = factory.ReservationDao.All().FirstOrDefault(p => p.Id == reservation.Id);
            if (checkedReservation == null)
                throw new FaultException(new FaultReason("Reservation not found!!!"), new FaultCode("404"), "");
            factory.ReservationDao.Update(reservation);
        }
    }

    public void DeleteReservation(int id)
    {
        using (DAOFactory factory = _daoFactory)
        {
            Reservation checkedReservation = factory.ReservationDao.All().FirstOrDefault(p => p.Id == id);
            if (checkedReservation == null)
                throw new FaultException(new FaultReason("Reservation not found!!!"), new FaultCode("404"), "");
            factory.ReservationDao.Remove(checkedReservation);
        }
    }

}