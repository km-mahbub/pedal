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
    public class RentRepository: Repository<Rent>, IRentRepository
    {
        public RentRepository(ApplicationDbContext context) : base(context)
        {
        }
        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;

        public Rent GetRentByTrackId(string trackId)
        {
            return ApplicationDbContext.Rents.Where(c => c.IsReceived != true).SingleOrDefault(c=>c.TrackId==trackId);
        }
    }
}
