using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Data.EntityTypeConfiguration
{
    class StoreConfiguration: EntityTypeConfiguration<Store>
    {
        public StoreConfiguration()
        {
            Property(s => s.TotalCycle)
                .HasColumnAnnotation("Default", 0);
            Property(a => a.IsDeleted)
                .HasColumnAnnotation("Default", false);

            Property(s => s.Name)
                .IsRequired();
            Property(s => s.IdentityId)
                .IsOptional();

        }

    }
}
