using System.ServiceModel;
using DataServices.Model;

namespace DataServices.Service
{
    [ServiceContract(Namespace = "http://agencytravel/user/")]

    public interface IUserServices
    {
        [OperationContract]
        public User[] GetUsers();
        [OperationContract]
        public User GetUser(string email, string? username);
        [OperationContract]
        public void CreateUser(User user);
        [OperationContract]
        public void UpdateUser(User user);

    }
}
