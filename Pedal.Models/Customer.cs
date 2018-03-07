﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string IdentityId { get; set; }
        public ApplicationUser Identity { get; set; }
        public int TotalRentHour { get; set; }
        public int TotalRentCount { get; set; }
    }
}