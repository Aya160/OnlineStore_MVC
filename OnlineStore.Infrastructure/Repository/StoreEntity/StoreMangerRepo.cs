using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.StoreEntity
{
    public class StoreMangerRepo<T> : IGenaricRepository<T> where T : StoreManager
    {
        private readonly ApplicationDbContext context;

        public StoreMangerRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.StoreManagers.Include(s => s.Store).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.StoreManagers.Include(s => s.Store).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.StoreManagers.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.StoreManagers.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            StoreManager entity = await context.StoreManagers.FindAsync(id);
            entity!.IsDeleted = true;
            context.StoreManagers.Update(entity);
            await context.SaveChangesAsync();
        }

    }
}
