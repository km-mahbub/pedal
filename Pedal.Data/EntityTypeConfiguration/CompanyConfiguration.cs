using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Data.EntityTypeConfiguration
{
    class CompanyConfiguration: EntityTypeConfiguration<Company>
    {
        public CompanyConfiguration()
        {
            Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);
            Property(a => a.IsDeleted)
                .HasColumnAnnotation("Default", false);

        }
    }
}
