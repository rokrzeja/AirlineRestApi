using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class FlightInstanceEmployeeAssociation
    {
        public int flightInstanceEmployeeAssociationId { get; set; }
        public int flightInstanceId { get; set; }
        public FlightInstance flightInstance { get; set; }

        public int employeeId { get; set; }
        public Employee employee { get; set; }
    }
}
