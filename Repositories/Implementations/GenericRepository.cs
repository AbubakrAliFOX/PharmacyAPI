using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Data.Repositories.Interfaces;

namespace PharmacyAPI.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T>
        where T : class
    {
        protected readonly DataContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
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
