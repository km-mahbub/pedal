using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Data
{
    public class PedalDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Cash> CashBook { get; set; }
    }
}
