using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public DateTime BookingTime { get; set; }
        public bool BookingStatus { get; set; }
        public BookingStatusTable BookingStatusTable { get; set; }
        public string BookingTrackId { get; set; }
        public Cycle Cycle { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Rent Rent { get; set; }
        public bool IsDeleted { get; set; }
    }
}
