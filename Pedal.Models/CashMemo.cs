﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Models
{
    public class CashMemo
    {
        public int CashMemoId { get; set; }
        public int RentId { get; set; }
        public int RentedHour { get; set; }
        public int StoreId { get; set; }
        public DateTime CashReceiveTime { get; set; }
        public Rent Rent { get; set; }
        public Store Store { get; set; }
    }
}