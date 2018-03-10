using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedal.Web.ViewModels
{
    public class CycleViewModel
    {
        public Cycle Cycle { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<Store> Stores { get; set; }

    }
}