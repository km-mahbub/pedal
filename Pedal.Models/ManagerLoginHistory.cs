using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Models
{
    public class ManagerLoginHistory
    {
        public int ManagerLoginHistoryId { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
        public string ManagerId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
