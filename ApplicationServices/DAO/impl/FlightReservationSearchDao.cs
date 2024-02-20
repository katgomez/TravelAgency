
using ApplicationServices.Data;
using ApplicationServices.Model;
using ApplicationServices.Models.Statistics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

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

    public async Task<List<AirportStatisticsInfo>> GetAirportReservationSearchStatistics()
    {
        var groupedByItinerary = await _dataContext.FlightReservationSearches
                                    .GroupBy(r => r.SearchId)
                                    .ToListAsync();
        var arrivalInfo = groupedByItinerary
                                .SelectMany(group => group
                                    .GroupBy(r => r.ArrivalAirport)
                                    .Select(g => new AirportStatisticsInfo
                                    {
                                        ItineraryCode = group.Key,
                                        AirportCode = g.Key,
                                        AirportCount = 1
                                    }))
                                .ToList();

        var departureInfo = groupedByItinerary
                                .SelectMany(group => group
                                    .GroupBy(r => r.DepartureAirport)
                                    .Select(g => new AirportStatisticsInfo
                                    {
                                        ItineraryCode = group.Key,
                                        AirportCode = g.Key,
                                        AirportCount = 1
                                    }))
                                .ToList();

        return arrivalInfo.Concat(departureInfo)
            .GroupBy(c => c.AirportCode)
            .Select(g => new AirportStatisticsInfo { AirportCode = g.Key, AirportCount = g.Sum(c => c.AirportCount) })
            .ToList();
    }

}