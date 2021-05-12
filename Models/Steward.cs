using project.Models.Associations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Steward : Employee
    {
        public bool bonus { get; set; }

        public ICollection<StewardLanguageAssociation> stewardLanguageList { get; set; }
    }
}
