using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Data.EntityTypeConfiguration
{
    class ManagerConfiguration: EntityTypeConfiguration<Manager>
    {
        public ManagerConfiguration()
        {
            Property(m => m.IsLoggedIn)
                .HasColumnAnnotation("Default", 0);

            HasRequired(s => s.Store)
                .WithOptional(m => m.Manager);
        }
    }
}
