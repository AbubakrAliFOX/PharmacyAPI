using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyAPI.Models;

namespace PharmacyAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        void Add(User entity);
        Task Update(User entity);
        Task Delete(int id);
    }
}
