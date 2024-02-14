using System.ServiceModel;
using WS.DataServices.Model;

namespace WS.DataServices.Service;

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