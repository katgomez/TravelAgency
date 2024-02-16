using DataServices;
using DataServices.DAO;
using DataServices.DAO.Impl;
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
