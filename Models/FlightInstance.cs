using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class FlightInstance
    {

        public int flightInstanceId { get; set; }
        public int flightNumber { get; set; }
        public DateTime  departureDate { get; set; }
        public DateTime arrivalDate { get; set; }
        public int ticketPrice { get; set; }

        public int flightId { get; set; }
        public Flight flight { get; set; }

        public ICollection<Reservation> reservations { get; set; }
        public ICollection<FlightInstanceEmployeeAssociation> FlightInstanceEmployeelist { get; set; }
    }
}
