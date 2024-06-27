using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.StoreEntity
{
    public class StoreRepo<T> : IGenaricRepository<T> where T : Store
    {
        private readonly ApplicationDbContext context;

        public StoreRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.Stores.Include(s => s.Administrator).Include(s => s.StoreManager).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.Stores.Include(s => s.Administrator).Include(s => s.StoreManager).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.Stores.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.Stores.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Store entity = await context.Stores.FindAsync(id);
            entity!.IsDeleted = true;
            context.Stores.Update(entity);
            await context.SaveChangesAsync();
        }

    }
}
