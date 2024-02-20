using System.ServiceModel;
using ApplicationServices.Models.Statistics;
using DataServices.Model;

namespace DataServices.Service;

[ServiceContract(Namespace = "http://agencytravel/flight/")]

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

    [OperationContract]
    public List<AirportStatisticsInfo> GetAirportReservationStatistics();

}