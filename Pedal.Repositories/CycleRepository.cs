using Pedal.Models;
using Pedal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedal.Data;
using System.Data.Entity;

namespace Pedal.Repositories
{
    public class CycleRepository:Repository<Cycle>, ICycleRepository
    {

        public CycleRepository(ApplicationDbContext context) : base(context)
        {
        }
        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;

        public Cycle GetCycleWithDetails(int id)
        {
            return ApplicationDbContext.Cycles.Where(b => b.IsDeleted == false).Include(c => c.Company).Include(c => c.Store).SingleOrDefault(c => c.CycleId == id);
        }

        public IEnumerable<Cycle> GetAllWithDetails()
        {
            return ApplicationDbContext.Cycles.Where(b => b.IsDeleted == false).Include(c => c.Company).Include(c => c.Store);
        }

        public IEnumerable<Cycle> GetCycleByStoreId(int id)
        {
            return ApplicationDbContext.Cycles.Include(c => c.Company).Include(c => c.Store).Where(s => s.StoreId == id).Where(c => c.IsDeleted != true).Where(c => c.CycleStatusType == CycleStatusType.Available);
        }

        public IEnumerable<Cycle> GetCycleForManager(int id)
        {
            return ApplicationDbContext.Cycles.Include(c => c.Company).Include(c => c.Store).Where(s => s.StoreId == id).Where(c => c.IsDeleted != true).Where(c => c.CycleStatusType != CycleStatusType.Rented);
        }
    }
}
