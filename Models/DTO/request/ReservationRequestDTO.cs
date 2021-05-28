using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models.DTO.request
{
    public class ReservationRequestDTO
    {
        public int NumberOfPassengers { get; set; }
        public int ClientPersonalId { get; set; }
        public int FlightNumber { get; set; }
    }
}
