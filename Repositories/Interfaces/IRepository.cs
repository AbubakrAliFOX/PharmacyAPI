using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Data.Repositories.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}