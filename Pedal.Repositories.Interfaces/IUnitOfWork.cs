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
        IBookingStatusTableRepository BookingStatusTableRepositories { get; }
        ICashMemoRepository CashMemoRepositories { get; }
        ICompanyRepository CompanyRepositories { get; }
        ICustomerRepository CustomerRepositories { get; }
        ICycleRepository CycleRepositories { get; }
        IManagerRepository ManagerRepositories { get; }
        IRentRepository RentRepositories { get; }
        IStoreRepository StoreRepository { get; }

        int Complete();
    }
}
