using Pedal.Models;
using Pedal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedal.Data;
using static System.Data.Entity.DbFunctions;

namespace Pedal.Repositories
{
    public class CashMemoRepository: Repository<CashMemo>, ICashMemoRepository
    {
        public CashMemoRepository(ApplicationDbContext context) : base(context)
        {
        }
        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;
        public IEnumerable<CashMemo> GetRentHistoryByUserId(string id)
        {
            return ApplicationDbContext.CashMemos.Where(b => b.CustomerId == id).Include(b => b.Store)
                .Include(r => r.Rent);
        }

        public IEnumerable<CashMemo> GetDailyTransectionByStore(int id)
        {
            return ApplicationDbContext.CashMemos.Where(b=>b.StoreId ==id).Where(b => TruncateTime(b.CashReceiveTime) == TruncateTime(DateTime.Now))
                .Include(b => b.Store).Include(b => b.Rent);
        }
    }
}
