using WebApplication2.Models;
using WebApplication2.Models.Repositories;

namespace WebApplication2.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Companies = new CompanyRepo(_context);
            Employees = new EmployeeRepo(_context);

            // other repo's..
        }

        public ICompanyRepo Companies { get; private set; }

        public IEmployeeRepo Employees { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        // other repo's..

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}