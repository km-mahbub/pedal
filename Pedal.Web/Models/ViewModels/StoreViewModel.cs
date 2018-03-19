using Pedal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pedal.Web.Models.ViewModels
{
    public class StoreViewModel
    {
        public int StoreId { get; set; }
        public int AddressId { get; set; }
       // public Address Address { get; set; }
        [Required]
        public String Name { get; set; }
        public int TotalCycle { get; set; }



        //Address 
        public Double Lat { get; set; }
        public Double Lon { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }


        public IEnumerable<Store> Stores { get; set; }
        public IEnumerable<ApplicationUser> AppUsers { get; set; }
    }
}