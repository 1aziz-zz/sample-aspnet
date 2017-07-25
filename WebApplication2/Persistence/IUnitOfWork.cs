using System;
using WebApplication2.Models.Repositories;

namespace WebApplication2.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepo Companies { get; }
        IEmployeeRepo Employees { get;  }

        // other repo's...
        int Complete();
    }
}