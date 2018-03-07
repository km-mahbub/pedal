﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Store> Stores { get; set; }
        public List<ApplicationUser> ApplicationUsers { get; set; }
    }
}
