﻿using Pedal.Models;
using Pedal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedal.Data;

namespace Pedal.Repositories
{
    public class CycleRepository:Repository<Cycle>, ICycleRepository
    {
        public CycleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
