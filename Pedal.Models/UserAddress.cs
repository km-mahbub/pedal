using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Models
{
    public class UserAddress
    {
        public int UserAddressId { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
