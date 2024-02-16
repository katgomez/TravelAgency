using DataServices.DAO.Impl;
using DataServices.DAO;

namespace DataServices
{
    public class DAOFactory : IDisposable
    {
        private DataContext _context;

        public DAOFactory()
        {
            _context = new DataContext();
        }

        public DAOFactory(DataContext fakeDataContext)
        {
            _context = fakeDataContext;
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