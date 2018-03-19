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
        public int? BookingId { get; set; }
        public Booking Booking { get; set; }
        public int RentedFromStoreId { get; set; }
        public int ToBeSubmittedStoreId { get; set; }
        public string ManagerId { get; set; }
        public bool IsReceived { get; set; }
        public string CustomerId { get; set; }
        public string TrackId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
