using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Models
{
    public class Rent
    {
        public int RentId { get; set; }
        public int CycleId { get; set; }
        public Cycle Cycle { get; set; }
        public int RentedHour { get; set; }
        public DateTime RentedTime { get; set; }
        public DateTime? ReturnTime { get; set; }
        public Booking Booking { get; set; }
        public int RentedFromStoreId { get; set; }
        public Store RentedFromStore { get; set; }
        public int ToBeSubmittedStoreId { get; set; }
        public Store ToBeSubmittedStore { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
