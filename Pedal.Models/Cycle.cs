using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Models
{
    public class Cycle
    {
        public int Cycleid { get; set; }
        [Required]
        public int Cycletypeid { get; set; }
        [Required]
        public int Companyid { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int Rentedhour { get; set; }
        [Required]
        public int Currentstoreid { get; set; }
        public int? Storeid { get; set; }

    }
}
