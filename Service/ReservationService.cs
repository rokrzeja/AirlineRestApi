using Microsoft.EntityFrameworkCore;
using project.Models;
using project.Models.DTO.request;
using project.Models.DTO.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Service
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetReservations();
        Task<bool> IsClientExist(int clientPersonalId);
        Task<bool> IsFlightInstanceExist(int flightNumber);
        Task<bool> IsAlreadyBooked(ReservationRequestDTO reservationRequestDTO);
        Task Book(ReservationRequestDTO reservationRequestDTO);
    }
    public class ReservationService : IReservationService
    {
        private MainDbContext _context = new MainDbContext();

        public async Task<List<Reservation>> GetReservations()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<bool> IsClientExist(int clientPersonalId)
        {
            var resultList = await _context.Clients
                                .Where(c => c.personalId == clientPersonalId).ToListAsync();

            return resultList.Any();
        }

        public async Task<bool> IsFlightInstanceExist(int flightNumber)
        {
            var resultList = await _context.FlightInstances
                            .Where(fi => fi.flightNumber == flightNumber).ToListAsync();

            return resultList.Any();
        }

        public async Task<bool> IsAlreadyBooked(ReservationRequestDTO reservationRequestDTO)
        {
            var resultList = await _context.Reservations
                            .Where(r => r.flightInstance.flightNumber == reservationRequestDTO.FlightNumber)
                            .Where(r => r.client.personalId == reservationRequestDTO.ClientPersonalId).ToListAsync();

            return !resultList.Any();
        }

        public async Task Book(ReservationRequestDTO reservationRequestDTO)
        {
            var client = await _context.Clients
                            .Where(c => c.personalId == reservationRequestDTO.ClientPersonalId).FirstAsync();

            var flightInstance = await _context.FlightInstances
                            .Where(fi => fi.flightNumber == reservationRequestDTO.FlightNumber).FirstAsync();

            Reservation reservation = new Reservation()
            {
                numberOfPassengers = reservationRequestDTO.NumberOfPassengers,
                flightClass = "Economy",
                extraLuggage = false,
                client = client,
                clientId = client.clientId,
                flightInstance = flightInstance,
                flightInstanceId = flightInstance.flightInstanceId
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
