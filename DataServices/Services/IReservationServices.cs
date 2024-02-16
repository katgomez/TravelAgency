using DataServices.Model;
using System.ServiceModel;

namespace DataServices.Services;


[ServiceContract(Namespace = "http://ws.agencytravel/reservation/")]

public interface IReservationServices
{
    [OperationContract]
    public Reservation[] GetReservations();

    [OperationContract]
    public Reservation[] GetReservationsByUserId(int id);

    [OperationContract]
    public Reservation GetReservationById(int id);

    [OperationContract]
    public void CreateReservation(Reservation reservation);

    [OperationContract]
    public void UpdateReservation(Reservation reservation);

}
