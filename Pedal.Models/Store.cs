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
        public Address Address { get; set; }
        public int TotalCycle { get; set; }
        public List<Cycle> Cycles { get; set; }
        public List<Rent> RentsFromThisStore { get; set; }
        public List<Rent> RentsSubmittedToThisStore { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<CashMemo> CashMemos { get; set; }
        public Manager Manager { get; set; }
        public bool IsDeleted { get; set; }
    }
}
