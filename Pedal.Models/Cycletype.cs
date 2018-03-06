using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Models
{
    public class Cycletype
    {
        public int Cycletypeid { get; set; }
        [Required]
        public string Cycletypename { get; set; }
    }
}
