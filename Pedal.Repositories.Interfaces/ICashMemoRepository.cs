using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Repositories.Interfaces
{
    public interface ICashMemoRepository :IRepository<CashMemo>
    {
        IEnumerable<CashMemo> GetRentHistoryByUserId(string id);
        IEnumerable<CashMemo> GetDailyTransectionByStore(int id);
        IEnumerable<CashMemo> GetDailyTransaction();
    }
}
