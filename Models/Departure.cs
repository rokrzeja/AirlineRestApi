using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace project.Models
{
    public partial class Departure
    {
        [Required]
        public int departureId { get; set; }
        [Required]
        public string airport { get; set; }
        [Required]
        public string airportShortcut { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string country { get; set; }

        public virtual ICollection<Flight> flights { get; set; }
    }
}
