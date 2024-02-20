
using ApplicationServices.Data;
using ApplicationServices.Model;
using ApplicationServices.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationServices.DAO.Impl;

public class FlightReservationSearchDao : GenericDAO<FlightReservationSearch>, IFlightReservationSearchDao
{

    private readonly DataContext _dataContext;
    public FlightReservationSearchDao(DataContext context) : base(context)
    {
        this._dataContext = context;
    }


    public  async  Task<IEnumerable<FlightReservationSearch>> FindByItineraryCode(string code)
    {
        return await _dataContext.FlightReservationSearches
            .Where(m => m.CodeOfItinerary == code)
            .ToListAsync();
    }

    public async Task<List<AirportStatisticsInfo>> GetReservationStatistics()
    {
        var arrivalInfo = await _dataContext.FlightReservationSearches
                                        .GroupBy(r => r.ArrivalAirport)
                                        .Select(g => new AirportStatisticsInfo { AirportCode = g.Key, AirportCount = g.Count() })
                                        .ToListAsync();

        var departureInfo = await _dataContext.FlightReservationSearches
                                        .GroupBy(r => r.DepartureAirport)
                                        .Select(g => new AirportStatisticsInfo { AirportCode = g.Key, AirportCount = g.Count() })
                                        .ToListAsync();

        return arrivalInfo.Concat(departureInfo)
            .GroupBy(c => c.AirportCode)
            .Select(g => new AirportStatisticsInfo { AirportCode = g.Key, AirportCount = g.Sum(c => c.AirportCount) })
            .ToList();
    }

}