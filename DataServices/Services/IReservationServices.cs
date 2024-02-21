using DataServices.Model;
using System.ServiceModel;

namespace DataServices.Service;


[ServiceContract(Namespace = "http://agencytravel/reservation/")]

public interface IReservationServices
{
    [OperationContract]
    public Reservation[] GetReservations();

    [OperationContract]
    public Reservation[] GetReservationsByUserId(int id);

    [OperationContract]
    public Reservation GetReservationById(int id);

    [OperationContract]
    public Task<int> CreateReservation(Reservation reservation);

    [OperationContract]
    public void UpdateReservation(Reservation reservation);
    [OperationContract]
    public void DeleteReservation(int id);

}
