using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyAPI.Models;

namespace PharmacyAPI.Repositories.Interfaces
{
    public interface IMetadataRepository
    {
        Task<List<Role>> GetRoles();
        Task<List<Branch>> GetBranches();
        Task<List<User>> GetManagers();
    }
}
