using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public int AddressId { get; set; }
        public String Name { get; set; }
        public int TotalCycle { get; set; }
        public string ManagerId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
