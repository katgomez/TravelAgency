using System.ServiceModel;
using DataServices.Model;

namespace DataServices.Service
{
    public class UserServices : IUserServices
    {
        private readonly DAOFactory _daoFactory;

        public UserServices()
        {
            _daoFactory = new DAOFactory();
        }
        public UserServices(DAOFactory daoFactory)
        {
            _daoFactory = daoFactory;
        }
        public void CreateUser(User user)
        {
            using (DAOFactory factory = _daoFactory)
            {
                User checkedUser = factory.UserDao.All().FirstOrDefault(p => p.Email == user.Email);
                if (checkedUser != null)
                    throw new FaultException(new FaultReason(
                    "User already exists!!!"), new FaultCode("400"), "");
                factory.UserDao.Add(user);
            }

        }

        public User GetUser(string? email)
        {
            using (DAOFactory factory = _daoFactory)
            {
                User[] users = factory.UserDao.All().ToArray();
                return users.First(p => p.Email == email);
            }
        }

        public User[] GetUsers()
        {
            using (DAOFactory factory = _daoFactory)
            {
                return factory.UserDao.All().ToArray();
            }

        }

        public void UpdateUser(User user)
        {
            using (DAOFactory factory = _daoFactory)
            {
                User checkedUser = factory.UserDao.All().FirstOrDefault(p => p.Email == user.Email);
                if (checkedUser == null)
                    throw new FaultException(new FaultReason(
                    "User not found!!!"), new FaultCode("404"), "");
                factory.UserDao.Update(user);
            }
        }

        public void DeleteUser(int id)
        {
            using (DAOFactory factory = _daoFactory)
            {
                User checkedUser = factory.UserDao.All().FirstOrDefault(p => p.Id == id);
                if (checkedUser == null)
                    throw new FaultException(new FaultReason(
                    "User not found!!!"), new FaultCode("404"), "");
                factory.UserDao.Remove(checkedUser);
            }
        }


    }
}
