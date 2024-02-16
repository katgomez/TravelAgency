using DataServices.Model;
using System.ServiceModel;

namespace DataServices.Services;

[ServiceContract(Namespace = "http://ws.agencytravel/flight/")]

public interface IFlightReservationServices
{
    [OperationContract]
    public FlightReservation[] GetFlights();
    [OperationContract]
    public FlightReservation GetFlight(int id);
    [OperationContract]
    public void CreateFlight(FlightReservation flightReservation);
    [OperationContract]
    public void UpdateFlight(FlightReservation flightReservation);

}