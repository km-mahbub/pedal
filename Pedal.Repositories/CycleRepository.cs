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

        public override IEnumerable<Cycle> GetAll()
        {
         
            return ApplicationDbContext.Cycles.Include(c => c.Company).Include(c => c.Store);
        }

        public IEnumerable<Cycle> GetAllWithDetails()
        {
            return ApplicationDbContext.Cycles.Include(c => c.Company).Include(c => c.Store);
        }

        
    }
}
