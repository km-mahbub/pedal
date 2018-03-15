using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Data.EntityTypeConfiguration
{
    class RentConfiguration: EntityTypeConfiguration<Rent>
    {
        public RentConfiguration()
        {
            Property(c => c.RentedTime)
                .IsRequired();
            Property(c => c.ManagerId)
                .IsRequired();
            Property(c => c.RentedHour)
                .HasColumnAnnotation("Default",0);
            Property(a => a.IsDeleted)
                .HasColumnAnnotation("Default", false);

        }
    }
}
