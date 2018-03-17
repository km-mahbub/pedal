using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedal.Web.Models.ViewModels
{
    public class CashMemoViewModel
    {
        public string TrackId { get; set; }
        public Rent Rent{ get; set; }
        public string RentedFromStoreName { get; set; }
        public Cycle Cycle { get; set; }
        public int RentId { get; set; }
        public int RentedHour { get; set; }
        public int TotalCost { get; set; }
        public string CustomerName { get; set; }
        public string CycleName { get; set; }
        public string ReceivedAtStoreName { get; set; }
    }
}