using System.ServiceModel;
using DataServices.Errors;
using DataServices.Model;

namespace DataServices.Service
{
    public class UserServices : IUserServices
    {
        private readonly DAOFactory _daoFactory;
        public UserServices(DAOFactory daoFactory)
        {
            _daoFactory = daoFactory ?? new DAOFactory();
        }
        public int CreateUser(User user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.Password))
            {
                return -1;
            }
            using (DAOFactory factory = _daoFactory)
            {
                User checkedUser = factory.UserDao.All().FirstOrDefault(p => p.Email == user.Email);
                if (checkedUser != null)
                    throw new FaultException(new FaultReason("User already exists!!!"), new FaultCode("400"), "");
                factory.UserDao.Add(user);
            }
            return user.Id;

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

        public User GetUserByEmail(string email)
        {
            using (DAOFactory factory = _daoFactory)
            {
                User[] users = factory.UserDao.All().ToArray();
                User user = users.FirstOrDefault(p => p.Email == email);
                if (user == null)
                {
                    throw new NotFoundException("User not found for the specified email address.");
                }
                return user;
            }
        }

        public User GetUserById(int id)
        {
            using (DAOFactory factory = _daoFactory)
            {
                User[] users = factory.UserDao.All().ToArray();
                User user = users.FirstOrDefault(p => p.Id == id);
                if (user == null)
                {
                    throw new NotFoundException("User not found for the specified email address.");
                }
                return user;
            }
        }
    }
}
