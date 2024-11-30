using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyAPI.Models;

namespace PharmacyAPI.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string username);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
