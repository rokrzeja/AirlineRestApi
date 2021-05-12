using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Client : Person
    {
        public int clientId { get; set; }
        public int documentNumber { get; set; }
        public ICollection<Reservation> reservations { get; set; }
    }
}
