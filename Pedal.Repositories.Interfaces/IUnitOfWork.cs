﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Pedal.Models;

namespace Pedal.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookingRepository Bookings { get; }
        IBookingStatusTableRepository BookingStatusTables { get; }
        ICashMemoRepository CashMemos { get; }
        ICompanyRepository Companies{ get; }
        ICycleRepository Cycles { get; }
        IRentRepository Rents { get; }
        IStoreRepository Stores { get; }
        IAddressRepository Addresses { get; }
        UserManager<ApplicationUser> UserManager { get; set; }

        int Complete();
    }
}
