using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Repositories.Interfaces
{
    public interface ICycleRepository:IRepository<Cycle>
    {
        Cycle GetCycleWithDetails(int id);
        IEnumerable<Cycle> GetAllWithDetails();
        IEnumerable<Cycle> GetCycleByStoreId(int id);
    }
}
