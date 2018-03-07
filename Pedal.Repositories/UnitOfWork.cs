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
            BookingStatusTableRepositories = new BookingStatusTableRepository(_context);
            CashMemoRepositories = new CashMemoRepository(_context);
            CompanyRepositories = new CompanyRepository(_context);
            CustomerRepositories = new CustomerRepository(_context);
            CycleRepositories = new CycleRepository(_context);
            ManagerRepositories = new ManagerRepository(_context);
            RentRepositories = new RentRepository(_context);
            StoreRepository = new StoreRepository(_context);
        }

        public IAdminRepository Admins { get; private set; }
        public IBookingRepository Bookings { get; private set; }
        public IBookingStatusTableRepository BookingStatusTableRepositories { get; private set; }
        public ICashMemoRepository CashMemoRepositories { get; }
        public ICompanyRepository CompanyRepositories { get; }
        public ICustomerRepository CustomerRepositories { get; }
        public ICycleRepository CycleRepositories { get; }
        public IManagerRepository ManagerRepositories { get; }
        public IRentRepository RentRepositories { get; }
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
