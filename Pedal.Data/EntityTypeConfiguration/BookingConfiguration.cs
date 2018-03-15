using System;
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
                .IsRequired()
                .HasMaxLength(255);
            Property(a => a.IsDeleted)
                .HasColumnAnnotation("Default", false);
        }
    }
}
