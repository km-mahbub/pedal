using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedal.Web.Models.ViewModels
{
    public class BookingToRentViewModel
    {
        public ApplicationUser Customer { get; set; }
        public ApplicationUser Manager { get; set; }
        public Cycle Cycle { get; set; }
        public DateTime RentedTime { get; set; }
        public Store Store { get; set; }
        public Booking Booking { get; set; }


    }
}