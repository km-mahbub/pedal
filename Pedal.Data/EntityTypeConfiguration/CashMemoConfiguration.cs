﻿using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Data.EntityTypeConfiguration
{
    class CashMemoConfiguration: EntityTypeConfiguration <CashMemo>
    {
        public CashMemoConfiguration()
        {
            Property(c => c.RentedHour)
                .IsRequired();
            Property(c => c.CashReceiveTime)
                .IsRequired();
            Property(a => a.IsDeleted)
                .HasColumnAnnotation("Default", false);


        }
    }
}
