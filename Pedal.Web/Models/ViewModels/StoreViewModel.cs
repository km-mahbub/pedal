using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedal.Web.Models.ViewModels
{
    public class StoreViewModel
    {
        public int StoreId { get; set; }
        public int AddressId { get; set; }
        public String Name { get; set; }
        public int TotalCycle { get; set; }
        public List<Cycle> Cycles { get; set; }
        public List<Rent> RentsFromThisStore { get; set; }
        public List<Rent> RentsSubmittedToThisStore { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<CashMemo> CashMemos { get; set; }
        public Manager Manager { get; set; }

        //Address 
        public Double Lat { get; set; }
        public Double Lon { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}