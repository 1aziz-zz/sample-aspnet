using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Persistence.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        T GetById(int? id);
        void Remove(T obj);
        void Add(T obj);
        void Update(T t);
        List<T> GetAll();
        void Save();
        void Dispose();
    }
}