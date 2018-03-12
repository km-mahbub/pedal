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
        private readonly ApplicationDbContext _context;

        public CycleRepository(ApplicationDbContext context) : base(context)
        {

            _context = context;
        }

        public override IEnumerable<Cycle> GetAll()
        {
         
            return _context.Cycles.Include(c => c.Company).Include(c => c.Store);
        }

        
    }
}
