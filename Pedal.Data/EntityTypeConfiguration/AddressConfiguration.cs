using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Data.EntityTypeConfiguration
{
    class AddressConfiguration: EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            Property(a => a.Area)
                .IsRequired();
            Property(a => a.City)
                .IsRequired();
            Property(a => a.Country)
                .IsRequired();
            Property(a => a.IsDeleted)
                .HasColumnAnnotation("Default", false);
        }
    }
}
