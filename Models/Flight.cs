using System;
using System.Collections.Generic;

#nullable disable

namespace project.Models
{
    public partial class Flight
    {
        public int flightId { get; set; }
        public string flightNumber { get; set; }
        public double fixedCost { get; set; }
        public double airportTax { get; set; }

        public int airplaneId { get; set; }
        public int arrivalId { get; set; }
        public int departureId { get; set; }
        public Airplane airplane { get; set; }
        public Arrival arrival { get; set; }
        public Departure departure { get; set; }

        public ICollection<FlightInstance> flightInstances { get; set; }
    }
}
