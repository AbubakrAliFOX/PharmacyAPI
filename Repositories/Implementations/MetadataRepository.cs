using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Data;
using PharmacyAPI.Models;
using PharmacyAPI.Repositories.Interfaces;

namespace PharmacyAPI.Repositories.Implementations
{
    public class MetadataRepository : IMetadataRepository
    {
        protected readonly DataContext _context;

        public MetadataRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetRoles()
        {
            return await _context.Roles.ToListAsync<Role>();
        }

        public async Task<List<Branch>> GetBranches()
        {
            return await _context.Branches.ToListAsync<Branch>();
        }

        public async Task<List<User>> GetManagers()
        {
            return await _context
                .Users.Include(user => user.Role)
                .Where(user => user.Role.Name == "Manager")
                .ToListAsync<User>();
        }
    }
}
