using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Data.EntityTypeConfiguration
{
    class CashMemoConfiguration: EntityTypeConfiguration <CashMemo>
    {
        public CashMemoConfiguration()
        {
            Property(c => c.RentedHour)
                .IsRequired();
            Property(c => c.CashReceiveTime)
                .IsRequired();

            HasRequired(m => m.Manager)
                .WithMany(c => c.CashMemos)
                .HasForeignKey(d => d.ManagerId);

            HasRequired(s => s.Store)
                .WithMany(c => c.CashMemos)
                .HasForeignKey(d => d.StoreId);
            HasRequired(m => m.Customer)
                .WithMany(c => c.CashMemos)
                .HasForeignKey(d => d.CustomerId);


        }
    }
}
