using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.Repositories;

namespace WebApplication2.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepo Companies { get; }

        // other repo's...
        int Complete();
    }
}