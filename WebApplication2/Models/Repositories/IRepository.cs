using System;
using System.Collections.Generic;

namespace WebApplication2.Models.Repositories
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        T GetById(int? id);
        void Delete(int? id);
        void Add(T obj);
        void Update(T t);
        List<T> GetAll();

        void Save();
    }
}