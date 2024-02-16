using WS.DataServices.Model;

namespace WS.DataServices.DAO.Impl
{
    public class UserDAO : GenericDAO<User>, IUserDAO
    {
        public UserDAO(DataContext context) : base(context)
        {
        }
    }
}
