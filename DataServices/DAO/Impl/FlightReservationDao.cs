using ApplicationServices.Models.Statistics;
using DataServices.Model;
using Microsoft.EntityFrameworkCore;

namespace DataServices.DAO.Impl;

public class FlightReservationDao : GenericDAO<FlightReservation>, IFlightReservationDao
{

    private readonly DataContext _dataContext;

    public FlightReservationDao(DataContext context) : base(context)
    {
        this._dataContext = context;



    }

    public async Task<List<AirportStatisticsInfo>> GetAirportReservationStatistics()
    {
        var arrivalInfo = await _dataContext.FlighReservations
                                        .GroupBy(r => r.ArrivalAirport)
                                        .Select(g => new AirportStatisticsInfo { AirportCode = g.Key, AirportCount = g.Count() })
                                        .ToListAsync();

        var departureInfo = await _dataContext.FlighReservations
                                        .GroupBy(r => r.DepartureAirport)
                                        .Select(g => new AirportStatisticsInfo { AirportCode = g.Key, AirportCount = g.Count() })
                                        .ToListAsync();

        return arrivalInfo.Concat(departureInfo)
            .GroupBy(c => c.AirportCode)
            .Select(g => new AirportStatisticsInfo { AirportCode = g.Key, AirportCount = g.Sum(c => c.AirportCount) })
            .ToList();
    }
}