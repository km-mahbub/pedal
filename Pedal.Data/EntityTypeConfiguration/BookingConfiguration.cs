﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedal.Models;

namespace Pedal.Data.EntityTypeConfiguration
{
    class BookingConfiguration : EntityTypeConfiguration<Booking>
    {
        public BookingConfiguration()
        {
            Property(c => c.BookingTime)
                .IsRequired();
            Property(c => c.BookingStatus)
                .IsRequired();
            Property(c => c.BookingTrackId)
                .IsRequired();

            HasRequired(c=>c.Store)
                .WithMany(s=>s.Bookings)
                .HasForeignKey(f=>f.StoreId)
                .WillCascadeOnDelete(false);
            HasRequired(c => c.Cycle)
                .WithRequiredDependent(s => s.Booking)
                .WillCascadeOnDelete(false);
        }
    }
}
