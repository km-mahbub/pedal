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
            Bookings = new BookingRepository(_context);
            BookingStatusTables = new BookingStatusTableRepository(_context);
            CashMemos = new CashMemoRepository(_context);
            Companies = new CompanyRepository(_context);
            Cycles = new CycleRepository(_context);
            Rents = new RentRepository(_context);
            Stores = new StoreRepository(_context);
            Addresses = new AddressRepository(_context);
        }
        
        public IBookingRepository Bookings { get; }
        public IBookingStatusTableRepository BookingStatusTables { get; }
        public ICashMemoRepository CashMemos { get; }
        public ICompanyRepository Companies { get; }
        public ICycleRepository Cycles { get; }
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
