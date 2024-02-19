
using ApplicationServices.Data;
using ApplicationServices.Model;
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

}