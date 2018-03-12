using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedal.Data;
using Pedal.Repositories.Interfaces;

namespace Pedal.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Admins = new AdminRepository(_context);
            Bookings = new BookingRepository(_context);
            BookingStatusTables = new BookingStatusTableRepository(_context);
            CashMemos = new CashMemoRepository(_context);
            Companies = new CompanyRepository(_context);
            Customers = new CustomerRepository(_context);
            Cycles = new CycleRepository(_context);
            Managers = new ManagerRepository(_context);
            Rents = new RentRepository(_context);
            Stores = new StoreRepository(_context);
            Addresses = new AddressRepository(_context);
        }


        public IAdminRepository Admins { get; }
        public IBookingRepository Bookings { get; }
        public IBookingStatusTableRepository BookingStatusTables { get; }
        public ICashMemoRepository CashMemos { get; }
        public ICompanyRepository Companies { get; }
        public ICustomerRepository Customers { get; }
        public ICycleRepository Cycles { get; }
        public IManagerRepository Managers { get; }
        public IRentRepository Rents { get; }
        public IStoreRepository Stores { get; }
        public IAddressRepository Addresses { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
