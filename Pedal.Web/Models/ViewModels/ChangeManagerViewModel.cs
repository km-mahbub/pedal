using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pedal.Models;

namespace Pedal.Web.Models.ViewModels
{
    public class ChangeManagerViewModel
    {
        public Store Store { get; set; }
        public int StoreId { get; set; }
        public ApplicationUser AppUser { get; set; }
        public IEnumerable<SelectListItem> Stores { get; set; }
        public IEnumerable<ApplicationUser> AppUsers { get; set; }
    }
}