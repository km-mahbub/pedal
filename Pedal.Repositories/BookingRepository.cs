using Pedal.Models;
using Pedal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Pedal.Data;

namespace Pedal.Repositories
{
    public class BookingRepository: Repository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationDbContext context) : base(context)
        {
        }
        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;

        public IEnumerable<Booking> GetBookedCycleByStoreId(int id)
        {

            //return ApplicationDbContext.Bookings.Where(b=>b.BookingTime.Subtract(DateTime.Now).TotalHours > -2).Where(b=>b.StoreId==id);

            return ApplicationDbContext.Bookings.Where(b => b.StoreId == id).Where(b => b.IsRented != true).Include(c => c.Cycle);
        }
    }
}
