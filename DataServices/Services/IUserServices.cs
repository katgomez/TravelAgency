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
        public User GetUserByEmail(string email);
        [OperationContract]
        public User GetUserById(int id);
        [OperationContract]
        public Task<int> CreateUser(User user);
        [OperationContract]
        public void UpdateUser(User user);
        [OperationContract]
        public void DeleteUser(int userId);

    }
}
