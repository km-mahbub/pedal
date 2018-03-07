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
    public class ManagerRepository: Repository<Manager>, IManagerRepository
    {
        public ManagerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
