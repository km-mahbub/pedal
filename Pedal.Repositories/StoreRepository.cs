using Pedal.Models;
using Pedal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedal.Data;

namespace Pedal.Repositories
{
    public class StoreRepository:Repository<Store>, IStoreRepository
    {
        public StoreRepository(ApplicationDbContext context) : base(context)
        {
        }
        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;

        public IEnumerable<Store> GetStoresWithAddress()
        {
            return ApplicationDbContext.Stores.Where(b => b.IsDeleted == false).Include(a => a.Address).ToList();
        }

        public Store GetStoreWithManager(string id)
        {
            return ApplicationDbContext.Stores.Where(b => b.IsDeleted == false).SingleOrDefault(c => c.ManagerId == id);
        }
    }
}
