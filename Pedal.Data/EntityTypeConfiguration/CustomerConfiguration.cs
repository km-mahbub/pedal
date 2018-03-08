using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Data.EntityTypeConfiguration
{
    class CustomerConfiguration: EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(c => c.TotalRentHour)
                .HasColumnAnnotation("Default", 0);
            Property(c => c.TotalRentCount)
                .HasColumnAnnotation("Default", 0);
            Property(a => a.IsDeleted)
                .HasColumnAnnotation("Default", false);
        }
    }
}
