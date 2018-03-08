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

        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
            AdminRepository = new AdminRepository(_context);
            BookingRepository = new BookingRepository(_context);
            BookingStatusTableRepository = new BookingStatusTableRepository(_context);
            CashMemoRepository = new CashMemoRepository(_context);
            CompanyRepository = new CompanyRepository(_context);
            CustomerRepository = new CustomerRepository(_context);
            CycleRepository = new CycleRepository(_context);
            ManagerRepository = new ManagerRepository(_context);
            RentRepository = new RentRepository(_context);
            StoreRepository = new StoreRepository(_context);
        }


        public IAdminRepository AdminRepository { get; }
        public IBookingRepository BookingRepository { get; }
        public IBookingStatusTableRepository BookingStatusTableRepository { get; }
        public ICashMemoRepository CashMemoRepository { get; }
        public ICompanyRepository CompanyRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public ICycleRepository CycleRepository { get; }
        public IManagerRepository ManagerRepository { get; }
        public IRentRepository RentRepository { get; }
        public IStoreRepository StoreRepository { get; }

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
