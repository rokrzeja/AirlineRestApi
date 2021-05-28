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
    public interface IDepartureService
    {
        Task<List<Departure>> GetPlaces();
        Task<List<OrderedPlace>> GetDeparturesOrderedByCountry();
        Task AddDeparture(Departure departure);
        Task <bool> IsAirportShortcutExist(string airportShortcut);
        Task <bool> IsPossibleToDeletePlace(string airportShortcut);
        Task DeletePlace(string airportShortcut);
    }
    public class DepartureService : IDepartureService
    {
        private MainDbContext _context = new MainDbContext();

        public async Task<List<Departure>> GetPlaces()
        {
            return await _context.Departures.ToListAsync();
        }

        public async Task<List<OrderedPlace>> GetDeparturesOrderedByCountry()
        {
            var resultList = await _context.Departures
                                .OrderBy(d => d.country)
                                .Select(d => new OrderedPlace()
                                {
                                    Country = d.country,
                                    City = d.city
                                }).ToListAsync();

            return resultList;
        }

        public async Task AddDeparture(Departure departure)
        {
            _context.Departures.Add(departure);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsAirportShortcutExist(string airportShortcut)
        {
            var resultList = await _context.Departures
                            .Where(d => d.airportShortcut == airportShortcut).ToListAsync();

            return resultList.Any();
        }
        public async Task<bool> IsPossibleToDeletePlace(string airportShortcut)
        {
            var resultList = await _context.Flights
                            .Where(d => d.departure.airportShortcut.Equals(airportShortcut)).ToListAsync();

            return !resultList.Any();
        }
        public async Task DeletePlace(string airportShortcut)
        {
            var place = await FindPlaceByAirportShortcut(airportShortcut);

            _context.Departures.Attach(place);
            _context.Entry(place).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<Departure> FindPlaceByAirportShortcut(string airportShortcut)
        {
            return await _context.Departures
                            .Where(d => d.airportShortcut == airportShortcut).FirstAsync();
        }
    }
}
