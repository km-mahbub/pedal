using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedal.Models;

namespace Pedal.Data.EntityTypeConfiguration
{
    class CycleConfiguration: EntityTypeConfiguration<Cycle>
    {
        public CycleConfiguration()
        {
            Property(c => c.CycleStatusType)
                .IsRequired();
            Property(c => c.RentedHour)
                .HasColumnAnnotation("Default", 0);
            Property(c => c.CycleType)
                .IsRequired();
            Property(a => a.IsDeleted)
                .HasColumnAnnotation("Default", false);



        }
    }
}
