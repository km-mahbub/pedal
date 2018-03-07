using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string IdentityId { get; set; }
        public ApplicationUser Identity { get; set; }
    }
}
