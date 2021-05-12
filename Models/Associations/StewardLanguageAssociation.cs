using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models.Associations
{
    public class StewardLanguageAssociation
    {

        public int stewardLanguageAssociationId { get; set; }
        public int employeeId { get; set; }
        public  Steward steward { get; set; }
        public int languageId { get; set; }
        public Language language { get; set; }
    }
}
