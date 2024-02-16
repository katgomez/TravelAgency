using DataServices;
using DataServices.Model;

namespace DataServices.DAO.Impl
{
    public class UserDAO : GenericDAO<User>, IUserDAO
    {
        public UserDAO(DataContext context) : base(context)
        {
        }
    }
}
