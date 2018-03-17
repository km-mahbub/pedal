using Pedal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pedal.Web.Models.ViewModels
{
    public class CashMemoViewModel
    {
        public string TrackId { get; set; }
        public Rent Rent{ get; set; }
        [Display(Name = "Rented From Store")]
        public string RentedFromStoreName { get; set; }
        public Cycle Cycle { get; set; }
        public int RentId { get; set; }
        [Display(Name = "Rented Duration")]
        public int RentedHour { get; set; }
        [Display(Name = "Total Cost")]
        public int TotalCost { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Cycle Name")]
        public string CycleName { get; set; }
        public string ReceivedAtStoreName { get; set; }
    }
}