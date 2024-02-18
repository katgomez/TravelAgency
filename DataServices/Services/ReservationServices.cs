using System.ServiceModel;
using DataServices.Model;

namespace DataServices.Service;

public class ReservationServices : IReservationServices
{
    DataContext _dbContext = new DataContext();
    public Reservation[] GetReservations()
    {
        return _dbContext.Reservations.ToArray();
    }

    public Reservation[] GetReservationsByUserId(int id)
    {
        return _dbContext.Reservations.Where(reservation => reservation.UserId == id).ToArray();
    }

    public Reservation GetReservationById(int id)
    {
        return _dbContext.Reservations.First(p => p.Id == id);
    }

    public void CreateReservation(Reservation reservation)
    {
        Reservation checkedReservation = _dbContext.Reservations.FirstOrDefault(p => p.Id == reservation.Id);
        if (checkedReservation != null)
            throw new FaultException(new FaultReason("Reservation already exists!!!"), new FaultCode("400"), "");
        _dbContext.Reservations.Add(reservation);
    }

    public void UpdateReservation(Reservation reservation)
    {
        Reservation checkedReservation = _dbContext.Reservations.FirstOrDefault(p => p.Id == reservation.Id);
        if (checkedReservation == null)
            throw new FaultException(new FaultReason("Reservation not found!!!"), new FaultCode("404"), "");
        _dbContext.Reservations.Update(reservation);
    }

    public void DeleteReservation(int id)
    {
        Reservation checkedReservation = _dbContext.Reservations.FirstOrDefault(p => p.Id == id);
        if (checkedReservation == null)
            throw new FaultException(new FaultReason("Reservation not found!!!"), new FaultCode("404"), "");
        _dbContext.Reservations.Remove(checkedReservation);
    }

}