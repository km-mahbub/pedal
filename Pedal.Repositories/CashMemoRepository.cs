using Pedal.Models;
using Pedal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedal.Data;

namespace Pedal.Repositories
{
    public class CashMemoRepository: Repository<CashMemo>, ICashMemoRepository
    {
        public CashMemoRepository(ApplicationDbContext context) : base(context)
        {
        }
        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;
    }
}
