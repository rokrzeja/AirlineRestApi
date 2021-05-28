using Microsoft.EntityFrameworkCore;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Service
{
    public interface IFlightService
    {
        Task<List<Flight>> GetFlights();
        Task<bool> IsAirplaneExist(int id);
        Task<bool> IsDeparturePlaceExist(int id);
        Task<bool> IsArrivalPlaceExist(int id);
        Task AddFlight(Flight flight);
        Task<bool> IsFlightExist(string flightNumber);
        Task<bool> IsPossibleToDelete(string flightNumber);
        Task DeleteFlight(string flightNumber);
    }
    public class FlightService : IFlightService
    {
        private MainDbContext _context = new MainDbContext();

        public async Task<List<Flight>> GetFlights()
        {
            return await _context.Flights.ToListAsync();
        }

        public async Task<bool> IsAirplaneExist(int id)
        {
            var resultList = await _context.Airplanes
                                .Where(a => a.airplaneId == id).ToListAsync();

            return resultList.Any();
        }
        public async Task<bool> IsDeparturePlaceExist(int id)
        {
            var resultList = await _context.Departures
                                .Where(a => a.departureId == id).ToListAsync();

            return resultList.Any();
        }

        public async Task<bool> IsArrivalPlaceExist(int id)
        {
            var resultList = await _context.Arrivals
                                .Where(a => a.arrivalId == id).ToListAsync();

            return resultList.Any();
        }


        public async Task AddFlight(Flight flight)
        {
            _context.Add(flight);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsFlightExist(string flightNumber)
        {
            var resultList = await _context.Flights
                                .Where(f => f.flightNumber == flightNumber).ToListAsync();

            return resultList.Any();
        }
        public async Task<bool> IsPossibleToDelete(string flightNumber)
        {
            var resultList = await _context.FlightInstances
                                    .Where(fi => fi.flight.flightNumber.Equals(flightNumber))
                                    .Where(fi => fi.reservations.Count() > 0).ToListAsync();

            return !resultList.Any();
        }

        public async Task DeleteFlight(string flightNumber)
        {
            var flight = await _context.Flights
                            .Where(f => f.flightNumber == flightNumber).FirstAsync();

            _context.Flights.Attach(flight);
            _context.Entry(flight).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }


    }
}
