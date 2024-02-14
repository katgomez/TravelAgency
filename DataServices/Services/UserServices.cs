using System.ServiceModel;
using System.Xml.Linq;
using WS.DataServices.Model;

namespace WS.DataServices.Service
{
    public class UserServices : IUserServices
    {
        public void CreateUser(User user)
        {
            using (DAOFactory factory = new DAOFactory())
            {
                User checkedUser = factory.UserDao.All().FirstOrDefault(p => p.Email == user.Email);
                if (checkedUser != null)
                    throw new FaultException(new FaultReason(
                    "User already exists!!!"), new FaultCode("400"), "");
                factory.UserDao.Add(user);
            }

        }

        public User GetUser(string? email, string? username)
        {
            using (DAOFactory factory = new DAOFactory())
            {
                User[] users = factory.UserDao.All().ToArray();
                return users.First(p => p.Email == email || p.UserName == username);
            }
        }

        public User[] GetUsers()
        {
            using (DAOFactory factory = new DAOFactory())
            {
                return factory.UserDao.All().ToArray();
            }

        }

        public void UpdateUser(User user)
        {
            using (DAOFactory factory = new DAOFactory())
            {
                User checkedUser = factory.UserDao.All().FirstOrDefault(p => p.Email == user.Email);
                if (checkedUser == null)
                    throw new FaultException(new FaultReason(
                    "Product not found!!!"), new FaultCode("404"), "");
                factory.UserDao.Update(user);
            }
        }
    }
}
