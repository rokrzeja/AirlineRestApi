using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Airplane
    {
        //[Required]
        public int airplaneId { get; set; }
        //[Required]
        public string code { get; set; }
       // [Required]
        public string shortcut { get; set; }
       // [Required]
        public string fullName { get; set; }
     //   [Required]
        public int economyClassCapacity { get; set; }
      //  [Required]
        public int businessClassCapacity { get; set; }
      //  [Required]
        public int firstClassCapacity { get; set; }
      //  [Required]
        public int range { get; set; }
      //  [Required]
        public int productionYear { get; set; }
      //  [Required]
        public string manufacturer { get; set; }
      //  [Required]
        public double hoursFlown { get; set; }
      //  [Required]
        public DateTime dateOfLastService { get; set; }
        public virtual ICollection<Flight> flights { get; set; }

        public void metoda()
        {

        }
    }
}
