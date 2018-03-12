using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAdminRepository Admins { get; }
        IBookingRepository Bookings { get; }
        IBookingStatusTableRepository BookingStatusTables { get; }
        ICashMemoRepository CashMemos { get; }
        ICompanyRepository Companies{ get; }
        ICustomerRepository Customers { get; }
        ICycleRepository Cycles { get; }
        IManagerRepository Managers { get; }
        IRentRepository Rents { get; }
        IStoreRepository Stores { get; }
        IAddressRepository Addresses { get; }

        int Complete();
    }
}
