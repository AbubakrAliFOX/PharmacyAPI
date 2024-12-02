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
        Task Update(T entity);
        Task Delete(int id);
    }
}
