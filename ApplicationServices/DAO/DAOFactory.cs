using ApplicationServices.DAO.Impl;
using ApplicationServices.DAO;
using ApplicationServices.Data;

namespace ApplicationServices
{
    public class DAOFactory : IDisposable
    {
        private DataContext _context;

        public DAOFactory(DataContext dataContext)
        {
            _context = dataContext;
        }
        public IFlightReservationSearchDao FlightReservationSearchDao
        {
            get { return new FlightReservationSearchDao(_context); }
        }

        public void Dispose() { _context.Dispose(); }
    }
}