using Pedal.Models;
using Pedal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Repositories
{
    public class BookingStatusTableRepository: Repository<BookingStatusTable>, IBookingStatusTableRepository
    {
    }
}
