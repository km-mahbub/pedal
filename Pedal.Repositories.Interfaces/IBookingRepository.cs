using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Repositories.Interfaces
{
    public interface IBookingRepository :IRepository<Booking>
    {
        IEnumerable<Booking> GetBookedCycleByStoreId(int id);
        IEnumerable<Booking> GetBookingsByCustomerId(string id);

    }
}
