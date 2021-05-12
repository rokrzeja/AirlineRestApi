using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Reservation
    {
        public int reservationId { get; set; }
        public string flightClass { get; set; }
        public bool extraLuggage { get; set; }
        public DateTime dateOfPurchase { get; set; }

        public int flightInstanceId { get; set; }
        public FlightInstance flightInstance { get; set; }

        public int clientId { get; set; }
        public Client client { get; set; }
    }
}
