using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<Cycle> Cycles { get; set; }
    }
}
