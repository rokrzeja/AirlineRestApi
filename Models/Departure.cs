using System;
using System.Collections.Generic;

#nullable disable

namespace project.Models
{
    public partial class Departure
    {
        public int departureId { get; set; }
        public string airport { get; set; }
        public string airportShortcut { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public virtual ICollection<Flight> flights { get; set; }
    }
}
