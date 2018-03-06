using System;
using System.Collections.Generic;
using System.Text;

namespace Pedal.Models
{
    class Rent
    {
        public int RentId { get; set; }
        public int CycleId { get; set; }
        public int UserId { get; set; }
        public int TotalRentedHour { get; set; }
        public int RentedFromStoreId { get; set; }
        public int ToBeSubmittedStoreId { get; set; }
        public DateTime RentedTime { get; set; }
        public DateTime? ReturnTime { get; set; }
        public int? BookingId { get; set; }
        public int ManagerId { get; set; }
    }
}
