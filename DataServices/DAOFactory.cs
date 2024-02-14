using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS.DataServices;
using WS.DataServices.DAO;
using WS.DataServices.DAO.Impl;

namespace WS.DataServices
{
    public class DAOFactory : IDisposable
    {
        private DataContext _context;

        public DAOFactory()
        {
            _context = new DataContext();
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