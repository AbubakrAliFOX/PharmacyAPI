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
    public class UserRepository : IUserRepository
    {
        protected readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context
                .Users.Include(user => user.Branch)
                .Include(user => user.Role)
                .Where(user => user.Role.Name != "Admin")
                .ToListAsync<User>();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
            return user;
        }

        public async Task<User> Add(User user)
        {
            try
            {
                var addedUser = await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return addedUser.Entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task Update(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            try
            {
                var entity = await GetById(id);
                if (entity != null)
                {
                    _context.Users.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException(
                    "Cannot delete the user as it is associated with other entities.",
                    ex
                );
            }
        }
    }
}
