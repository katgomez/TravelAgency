﻿using DataServices.Model;
using DataServices.Models.Users;
using System.ServiceModel;

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

        [OperationContract]
        public long CountUsers();

        [OperationContract]
        public CheckCredentialsResult CheckCredentials(UserCredentials userCredentials);
    }
}
