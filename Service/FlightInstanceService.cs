using Microsoft.EntityFrameworkCore;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Service
{
    public interface IFlightInstanceService
    {
        Task<List<FlightInstance>> GetFlightInstances();
        Task<int> GetNumberOfBookedEconomySeats(int flightNumber);
        Task<int> GetNumberOfBookedBusinessSeats(int flightNumber);
        Task<int> GetNumberOfFirstClassBookedSeats(int flightNumber);
        Task<bool> IsFlightExist(int id);
        Task AddFlightInstance(FlightInstance flightInstance);
        Task AddDelay(int flightNumber, int delay);
        Task<bool> IsFlightInstanceExist(int id);
        Task<bool> IsPossibleToDeleteFlightInstance(int id);
        Task DeleteFlightInstance(int id);
    }

    public class FlightInstanceService : IFlightInstanceService
    {
        private MainDbContext _context = new MainDbContext();

        public async Task<List<FlightInstance>> GetFlightInstances()
        {
            return await _context.FlightInstances.ToListAsync();
        }

        public async Task<int> GetNumberOfBookedEconomySeats(int flightNumber)
        {
            int bookedSeats = 0;
            var list = await _context.Reservations
                                .Where(r => r.flightInstance.flightNumber == flightNumber)
                                .Where(r => r.flightClass.Equals("Economy")).ToListAsync();

            foreach(Reservation reservation in list)
            {
                bookedSeats += reservation.numberOfPassengers;
            }

            return bookedSeats;
        }

        public async Task<int> GetNumberOfBookedBusinessSeats(int flightNumber)
        {
            int bookedSeats = 0;
            var list = await _context.Reservations
                                .Where(r => r.flightInstance.flightNumber == flightNumber)
                                .Where(r => r.flightClass.Equals("Business")).ToListAsync();

            foreach (Reservation reservation in list)
            {
                bookedSeats += reservation.numberOfPassengers;
            }

            return bookedSeats;
        }

        public async Task<int> GetNumberOfFirstClassBookedSeats(int flightNumber)
        {
            int bookedSeats = 0;
            var list = await _context.Reservations
                                .Where(r => r.flightInstance.flightNumber == flightNumber)
                                .Where(r => r.flightClass.Equals("First")).ToListAsync();

            foreach (Reservation reservation in list)
            {
                bookedSeats += reservation.numberOfPassengers;
            }

            return bookedSeats;
        }

        public async Task<bool> IsFlightExist(int id)
        {
            var resultList = await _context.Flights
                                .Where(f => f.flightId == id).ToListAsync();

            return resultList.Any();
        }

        public async Task AddFlightInstance(FlightInstance flightInstance)
        {
            _context.FlightInstances.Add(flightInstance);
            await _context.SaveChangesAsync();
        }

        public async Task AddDelay(int flightNumber, int delay)
        {
            var flightInstance = await _context.FlightInstances
                                    .Where(fi => fi.flightNumber == flightNumber).FirstAsync();

            flightInstance.arrivalDate.AddMinutes(delay);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsFlightInstanceExist(int flightNumber)
        {
            var resultList = await _context.FlightInstances
                                .Where(fi => fi.flightNumber== flightNumber).ToListAsync();

            return resultList.Any();
        }

        public async Task<bool> IsPossibleToDeleteFlightInstance(int flightNumber)
        {
            var resultList = await _context.FlightInstances
                                .Where(fi => fi.flightNumber == flightNumber)
                                .Where(fi => fi.reservations.Count() > 0).ToListAsync();

            return !resultList.Any();
        }

        public async Task DeleteFlightInstance(int flightNumber)
        {
            var flightInstance = await _context.FlightInstances
                                    .Where(fi => fi.flightNumber == flightNumber).FirstAsync();

            _context.FlightInstances.Attach(flightInstance);
            _context.Entry(flightInstance).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
