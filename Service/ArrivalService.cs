using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using project.Models;
using project.Models.DTO.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Service
{
    public interface IArrivalService
    {
        Task<List<Arrival>> GetPlaces();
        Task<List<OrderedPlace>> GetArrivalsOrderedByCountry();
        Task AddArrival(Arrival arrival);
        Task<bool> IsAirportShortcutExist(string airportShortcut);
        Task<bool> IsPossibleToDeletePlace(string airportShortcut);
        Task DeletePlace(string airportShortcut);
    }
    public class ArrivalService : IArrivalService
    {
        private MainDbContext _context = new MainDbContext();

        public async Task<List<Arrival>> GetPlaces()
        {
            return await _context.Arrivals.ToListAsync();
        }

        public async Task<List<OrderedPlace>> GetArrivalsOrderedByCountry()
        {
            var resultList = await _context.Arrivals
                                .OrderBy(d => d.country)
                                .Select(d => new OrderedPlace()
                                {
                                    Country = d.country,
                                    City = d.city
                                }).ToListAsync();

            return resultList;
        }

        public async Task AddArrival(Arrival arrival)
        {
            _context.Arrivals.Add(arrival);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsAirportShortcutExist(string airportShortcut)
        {
            var resultList = await _context.Arrivals
                            .Where(d => d.airportShortcut == airportShortcut).ToListAsync();

            return resultList.Any();
        }
        public async Task<bool> IsPossibleToDeletePlace(string airportShortcut)
        {
            var resultList = await _context.Flights
                            .Where(d => d.arrival.airportShortcut.Equals(airportShortcut)).ToListAsync();

            return !resultList.Any();
        }
        public async Task DeletePlace(string airportShortcut)
        {
            var place = await FindPlaceByAirportShortcut(airportShortcut);

            _context.Arrivals.Attach(place);
            _context.Entry(place).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<Arrival> FindPlaceByAirportShortcut(string airportShortcut)
        {
            return await _context.Arrivals
                            .Where(d => d.airportShortcut == airportShortcut).FirstAsync();
        }
    }
}
