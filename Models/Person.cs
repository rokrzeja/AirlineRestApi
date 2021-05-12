using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public abstract class Person
    {
        public int personalId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string sex { get; set; }
        public DateTime birthDate { get; set; }
        public string birthPlace { get; set; }
        public string placeOfResidance { get; set; }
        public int telephoneNumber { get; set; }
        public string email { get; set; }
    }
}
