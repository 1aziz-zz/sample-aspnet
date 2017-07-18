using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication2.Persistence.Repositories;

namespace WebApplication2.Models.Repositories
{
    public interface ICompanyRepo : IRepository<Company>
    {
        bool WordConsistsOfMinFourLetters(string text);
    }
}