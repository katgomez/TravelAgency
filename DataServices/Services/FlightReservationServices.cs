using ApplicationServices.Models.Statistics;
using DataServices.DAO;
using DataServices.Model;
using System.ServiceModel;

namespace DataServices.Service;

public class FlightReservationServices : IFlightReservationServices
{
    DataContext _dbContext;
    IFlightReservationDao flightReservationDao;

    public FlightReservationServices()
    {
        _dbContext = new DataContext();
        DAOFactory factory = new DAOFactory(_dbContext);
        flightReservationDao = factory.FlightReservationDao;
    }

    public FlightReservationServices(DataContext dbContext)
    {
        _dbContext = dbContext;
    }
    public FlightReservation[] GetFlights()
    {
        return _dbContext.FlighReservations.ToArray();
    }

    public FlightReservation GetFlight(int id)
    {
        return _dbContext.FlighReservations.First(p => p.Id == id);
    }

    public async Task<int> CreateFlight(FlightReservation flightReservation)
    {
        FlightReservation flight = _dbContext.FlighReservations.FirstOrDefault(p => p.Id == flightReservation.Id);
        if (flight != null)
            throw new FaultException(new FaultReason("Flight already exists!!!"), new FaultCode("400"), "");
        await _dbContext.FlighReservations.AddAsync(flightReservation);
        await _dbContext.SaveChangesAsync();
        return flightReservation.Id;
    }


    public void UpdateFlight(FlightReservation flightReservation)
    {
        FlightReservation flight = _dbContext.FlighReservations.FirstOrDefault(p => p.Id == flightReservation.Id);
        if (flight == null)
            throw new FaultException(new FaultReason("Flight not found!!!"), new FaultCode("404"), "");
        _dbContext.FlighReservations.Update(flightReservation);
    }

    public List<AirportStatisticsInfo> GetAirportReservationStatistics()
    {
        return this.flightReservationDao.GetAirportReservationStatistics().Result;
    }


}