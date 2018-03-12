using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAdminRepository AdminRepository { get; }
        IBookingRepository BookingRepository { get; }
        IBookingStatusTableRepository BookingStatusTableRepository { get; }
        ICashMemoRepository CashMemoRepository { get; }
        ICompanyRepository CompanyRepository{ get; }
        ICustomerRepository CustomerRepository { get; }
        ICycleRepository CycleRepository { get; }
        IManagerRepository ManagerRepository { get; }
        IRentRepository RentRepository { get; }
        IStoreRepository StoreRepository { get; }
        IAddressRepository AddressRepository { get; }

        int Complete();
    }
}
