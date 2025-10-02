using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSystem.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<bool> CreateAsync(T Entity);
        public Task<bool> UpdateAsync(T Entity);
        public Task<T> GetByIdAsync(T entity, int id);
        public Task<bool> DeleteAsync(T entity);
    }
}
