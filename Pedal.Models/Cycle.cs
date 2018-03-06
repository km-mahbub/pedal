using System;
using System.Collections.Generic;
using System.Text;

namespace Pedal.Models
{
    public class Cycle
    {

         public int Cycleid { get; set; }
         public int Cycletypeid { get; set; }
         public int Companyid { get; set; }
         public string Status { get; set; }
         public int Rentedhour { get; set; }
         public int Currentstoreid { get; set; }
         public int? Storeid { get; set; }

        
    }

}

