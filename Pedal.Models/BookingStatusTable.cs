using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Models
{
    public class BookingStatusTable
    {
        public int BookingStatusTableId { get; set; }
        public bool IsRented { get; set; }
        public bool IsDeleted { get; set; }
    }
}
