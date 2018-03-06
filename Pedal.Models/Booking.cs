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
