using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Pedal.Data.EntityTypeConfiguration;
using Pedal.Models;

namespace Pedal.Data

{
    


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<BookingStatusTable> BookingStatusTables { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Cycle> Cycles { get; set; }
        public DbSet<ManagerLoginHistory> ManagerLoginHistories { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<CashMemo> CashMemos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new BookingConfiguration());
            modelBuilder.Configurations.Add(new BookingStatusTableConfiguration());
            modelBuilder.Configurations.Add(new CashMemoConfiguration());
            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new CycleConfiguration());
            modelBuilder.Configurations.Add(new ManagerConfiguration());
            modelBuilder.Configurations.Add(new ManagerLoginHistoryConfiguration());
            modelBuilder.Configurations.Add(new RentConfiguration());
            modelBuilder.Configurations.Add(new StoreConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
