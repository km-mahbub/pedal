using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public string IdentityId { get; set; }
        public ApplicationUser Identity { get; set; }
        public Store Store { get; set; }
        public bool IsLoggedIn { get; set; }
        public List<CashMemo> CashMemos { get; set; }
        public List<Rent> Rents { get; set; }
    }
}
