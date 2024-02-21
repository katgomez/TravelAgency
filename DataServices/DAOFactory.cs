using DataServices.DAO;
using DataServices.DAO.Impl;

namespace DataServices
{
    public class DAOFactory : IDisposable
    {
        private DataContext _context;

        public DAOFactory(DataContext dataContext)
        {
            _context = dataContext;
        }

        public IUserDAO UserDao
        {
            get { return new UserDAO(_context); }
        }

        public IReservationDAO ReservationDao
        {
            get { return new ReservationDAO(_context); }
        }

        public IFlightReservationDao FlightReservationDao
        {
            get { return new FlightReservationDao(_context); }
        }

        public void Dispose() { _context.Dispose(); }
    }
}