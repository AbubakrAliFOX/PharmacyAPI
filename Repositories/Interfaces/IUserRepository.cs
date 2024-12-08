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
        Task<User> GetByEmail(string email);
        Task<User> Add(User user);
        Task Update(User entity);
        Task Delete(int id);
        Task<bool> Deactivate(int id);
        Task<bool> Activate(int id);
    }
}
