﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Models
{
    public class Company
    {
        public int Companyid { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
