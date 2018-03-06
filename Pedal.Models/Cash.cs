using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Models
{
    public class Cash
    {
        [Required]
        public int CashId { get; set; }
        [Required]
        public int RentId { get; set; }
        [Required]
        public int RentedHour { get; set; }
        [Required]
        public int StoreId { get; set; }
        [Required]
        public int AdminId { get; set; }
        [Required]
        public DateTime CashReceiveTime { get; set; }
    }
}
