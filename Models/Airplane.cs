using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Airplane
    {

        public int airplaneId { get; set; }
        public string code { get; set; }
        public string shortcut { get; set; }
        public string fullName { get; set; }
        public int economyClassCapacity { get; set; }
        public int businessClassCapacity { get; set; }
        public int firstClassCapacity { get; set; }
        public int range { get; set; }
        public int productionYear { get; set; }
        public string manufacturer { get; set; }
        public double hoursFlown { get; set; }
        public DateTime dateOfLastService { get; set; }
        public virtual ICollection<Flight> flights { get; set; }
    }
}
