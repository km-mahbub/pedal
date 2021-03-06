﻿using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Repositories.Interfaces
{
    public interface IRentRepository: IRepository<Rent>
    {
        Rent GetRentByTrackId(string trackId);
        IEnumerable<Rent> GetDaliyRents();
    }
}
