using project.Models.Associations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Language
    {
        public int languageId { get; set; }
        public string language { get; set; }

        public ICollection<StewardLanguageAssociation> stewardLanguageList { get; set; }
    }
}
