using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Data.EntityTypeConfiguration
{
    class ApplicationUserConfiguration: EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(a => a.FirstName)
                .IsOptional()
                .HasMaxLength(64);
            Property(a => a.LastName)
                .IsOptional()
                .HasMaxLength(64);
            Property(a => a.Gender)
                .IsOptional();
            Property(a => a.NationalId)
                .IsOptional();
            Property(a => a.PassportNumber)
                .IsOptional();
            Property(a => a.DrivingLicense)
                .IsOptional();
            Property(a => a.IsDeleted)
                .HasColumnAnnotation("Default", false);

            HasOptional(c => c.Address)
                .WithMany(a => a.ApplicationUsers)
                .HasForeignKey(c => c.AddressId);
        }
    }
}
