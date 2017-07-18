using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication2.Models;
using WebApplication2.Models.Repositories;

namespace WebApplication2.DAL
{
    // Waarom zou ik hier een DTO gebruiken?
    public class CompanyRepo : IRepository<Company>, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        private bool _disposed;

        public CompanyRepo(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public List<Company> GetAll()
        {
            return _dbContext.Companies.ToList();
        }

        public Company GetById(int? id)
        {
            return _dbContext.Companies.Find(id);
        }

        public void Update(Company company)
        {
            _dbContext.Entry(company).State = EntityState.Modified;
        }

        public void Delete(int? id)
        {
            var company = _dbContext.Companies.Find(id);
            if (company != null) _dbContext.Companies.Remove(company);
        }

        public void Add(Company company)
        {
            _dbContext.Companies.Add(company);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}