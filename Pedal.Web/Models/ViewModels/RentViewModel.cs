using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pedal.Models;

namespace Pedal.Web.Models.ViewModels
{
    public class RentViewModel
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

        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string TrackId { get; set; }
        public int Pin { get; set; }
    }
}