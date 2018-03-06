using System;
using System.Collections.Generic;
using System.Text;

namespace Pedal.Models
{
    class Booking
    {
        [Required]
        public int BookingId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CycleId { get; set; }
        [Required]
        public int PickUpStoreId { get; set; }
        [Required]
        public DateTime BookingTime { get; set; }
        public Boolean BookingStatus { get; set; }
        public string BookingTrackId { get; set; }
    }
}
