using System.ServiceModel;
using DataServices.Errors;
using DataServices.Model;

namespace DataServices.Service
{
    public class UserServices : IUserServices
    {
        DataContext _dbContext = new DataContext();
        public int CreateUser(User user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.Password))
            {
                return -1;
            }
            User checkedUser = _dbContext.Users.Where(p => p.Email == user.Email).FirstOrDefault();
            if (checkedUser != null)
                throw new FaultException(new FaultReason("User already exists!!!"), new FaultCode("400"), "");
            _dbContext.Users.AddAsync(user);
            return user.Id;
        }

        public User[] GetUsers()
        {
            return _dbContext.Users.ToArray();
        }

        public void UpdateUser(User user)
        {
            User checkedUser = _dbContext.Users.Where(p => p.Id == user.Id).FirstOrDefault();
            if (checkedUser == null)
                throw new FaultException(new FaultReason("User not found!!!"), new FaultCode("404"), "");
            _dbContext.Users.Update(user);
            
        }

        public void DeleteUser(int id)
        {
            User checkedUser = _dbContext.Users.Where(p => p.Id == id).FirstOrDefault();
            if (checkedUser == null)
                throw new FaultException(new FaultReason(
                "User not found!!!"), new FaultCode("404"), "");
            _dbContext.Users.Remove(checkedUser);

        }

        public User GetUserByEmail(string email)
        {
            User user = _dbContext.Users.Where(p => p.Email == email).FirstOrDefault();
            if (user == null)
            {
                throw new NotFoundException("User not found for the specified email address.");
            }
            return user;
            
        }

        public User GetUserById(int id)
        {
            User user = _dbContext.Users.Where(p => p.Id == id).FirstOrDefault();
            if (user == null)
            {
                throw new NotFoundException("User not found for the specified email address.");
            }
            return user;
        }
    }
}
