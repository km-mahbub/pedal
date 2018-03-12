using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Pedal.Models;

namespace Pedal.Web.Models.ViewModels
{
    public class CycleViewModel
    {
        public int? CycleId { get; set; }
        public int? RentedHour { get; set; }
        [Display(Name = "Select Type")]
        public CycleType CycleType { get; set; }
        [Display(Name = "Select Company")]
        public int CompanyId { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        [Display(Name = "Select Store")]
        public int StoreId { get; set; }
        public IEnumerable<Store> Stores { get; set; }
        [Display(Name = "Select Status")]
        public CycleStatusType CycleStatusType { get; set; }
        public object Customer { get; internal set; }
        public CycleViewModel Cycles { get; internal set; }
    }
}