using System.ServiceModel;
using WS.DataServices.Model;

namespace WS.DataServices.Service;


[ServiceContract(Namespace = "http://ws.agencytravel/reservation/")]

public interface IReservationServices
{
    [OperationContract]
    public Reservation[] GetReservations();
    [OperationContract]
    public Reservation GetReservation(int id);
    [OperationContract]
    public void CreateReservation(Reservation reservation);
    [OperationContract]
    public void UpdateReservation(Reservation reservation);

}
