using OnlineStore.Core.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Core.IRepository
{
    public interface IGenaricRepository<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetById(int id);
        public Task CreateAsync(T entity);
        public Task UpdateAsync(int id,T entity);
        public Task DeleteAsync(int id);
    }
}
