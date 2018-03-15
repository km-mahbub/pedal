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
       // public Address Address { get; set; }
        public String Name { get; set; }
        public int TotalCycle { get; set; }



        //Address 
        public Double Lat { get; set; }
        public Double Lon { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}