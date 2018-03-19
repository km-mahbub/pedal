using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedal.Web.Models.ViewModels
{
    public class MostRentedStoreViewModel
    {
        public IEnumerable<Rent> Rents { get; set; }
        public IEnumerable<Store> Stores { get; set; }
        public IEnumerable<ApplicationUser> AppUsers { get; set; }

    }
}