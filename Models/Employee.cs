using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Employee : Person
    {
        public int employeeId { get; set; }
        public double hoursFlown { get; set; }
        public DateTime hireDate { get; set; }
        public string formerEmployer { get; set; }
        public double basicSalary { get; set; }
        public double hourlyRate { get; set; }

        public ICollection<FlightInstanceEmployeeAssociation> FlightInstanceEmployeelist { get; set; }
    }
}
