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

            HasRequired(c=>c.Cycle)
                .WithMany(s=>s.Rents)
                .HasForeignKey(f=>f.CycleId)
                .WillCascadeOnDelete(false);
            HasOptional(c => c.Booking)
                .WithOptionalDependent(s => s.Rent)
                .WillCascadeOnDelete(false);
            HasRequired(c=>c.RentedFromStore)
                .WithMany(s=>s.RentsFromThisStore)
                .HasForeignKey(f=>f.RentedFromStoreId)
                .WillCascadeOnDelete(false);
            HasRequired(c => c.ToBeSubmittedStore)
                .WithMany(s => s.RentsSubmittedToThisStore)
                .HasForeignKey(f => f.ToBeSubmittedStoreId)
                .WillCascadeOnDelete(false);
            HasRequired(m => m.Manager)
                .WithMany(r => r.Rents)
                .HasForeignKey(m => m.ManagerId)
                .WillCascadeOnDelete(false);
            HasRequired(m => m.Customer)
                .WithMany(r => r.Rents)
                .HasForeignKey(m => m.CustomerId)
                .WillCascadeOnDelete(false);

        }
    }
}
