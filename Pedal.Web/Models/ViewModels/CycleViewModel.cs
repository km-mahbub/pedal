using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pedal.Models;

namespace Pedal.Web.Models.ViewModels
{
    public class CycleViewModel
    {
        public int CycleId { get; set; }
        public int? RentedHour { get; set; }
        [Display(Name = "Select Type")]
        public CycleType CycleType { get; set; }
        [Display(Name = "Select Company")]
        public int CompanyId { get; set; }

        public IEnumerable<SelectListItem> CompanyList { get; set; }
        [Display(Name = "Select Store")]
        public int StoreId { get; set; }
        public IEnumerable<SelectListItem> StoreList { get; set; }
        [Display(Name = "Select Status")]
        public CycleStatusType CycleStatusType { get; set; }

        public Double CostPerHour { get; set; }
    }
}