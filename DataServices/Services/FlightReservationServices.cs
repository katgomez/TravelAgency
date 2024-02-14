using System.ServiceModel;
using WS.DataServices.Model;

namespace WS.DataServices.Service;

public class FlightReservationServices: IFlightReservationServices
{
    public FlightReservation[] GetFlights()
    {
        using (DAOFactory factory = new DAOFactory())
        {
            return factory.FlightReservationDao.All().ToArray();
        }
    }

    public FlightReservation GetFlight(int id)
    {
        using (DAOFactory factory = new DAOFactory())
        {
            FlightReservation[] flight = factory.FlightReservationDao.All().ToArray();
            return flight.First(p => p.Id == id);
        }
    }

    public void CreateFlight(FlightReservation flightReservation)
    {
        using (DAOFactory factory = new DAOFactory())
        {
            FlightReservation flight = factory.FlightReservationDao.All().FirstOrDefault(p => p.Id == flightReservation.Id);
            if (flight != null)
                throw new FaultException(new FaultReason("Flight already exists!!!"), new FaultCode("400"), "");
            factory.FlightReservationDao.Add(flightReservation);
        }
    }

    public void UpdateFlight(FlightReservation flightReservation)
    {
        using (DAOFactory factory = new DAOFactory())
        {
            FlightReservation flight = factory.FlightReservationDao.All().FirstOrDefault(p => p.Id == flightReservation.Id);
            if (flight == null)
                throw new FaultException(new FaultReason("Flight not found!!!"), new FaultCode("404"), "");
            factory.FlightReservationDao.Update(flightReservation);
        }
    }
}