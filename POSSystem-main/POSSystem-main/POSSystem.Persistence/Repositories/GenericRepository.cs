using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POSSystem.Application.Interfaces;
using POSSystem.Persistence.Data;

namespace POSSystem.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly POSSystemDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(POSSystemDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> CreateAsync(T entity)
        {
            var add = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            if (add != null)
                return true;
            return false;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(T entity, int id)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => EF.Property<int>(x, "Id") == id);
            return result;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            var add = _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            if (add != null)
                return true;
            return false;
        }
        public async Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        }
}
