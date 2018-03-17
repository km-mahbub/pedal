using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Models
{
    public class Cycle
    {
        public int CycleId { get; set; }
        public CycleStatusType CycleStatusType { get; set; }
        public int RentedHour { get; set; }
        public CycleType CycleType { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public double CostPerHour { get; set; }
        public bool IsDeleted { get; set; }
    }
}
