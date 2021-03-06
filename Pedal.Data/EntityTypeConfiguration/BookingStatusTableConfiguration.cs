﻿using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Data.EntityTypeConfiguration
{
    class BookingStatusTableConfiguration: EntityTypeConfiguration <BookingStatusTable>
    {
        public BookingStatusTableConfiguration()
        {
            Property(c => c.IsRented)
                .IsRequired();
            Property(a => a.IsDeleted)
                .HasColumnAnnotation("Default", false);
        }
    }
}
