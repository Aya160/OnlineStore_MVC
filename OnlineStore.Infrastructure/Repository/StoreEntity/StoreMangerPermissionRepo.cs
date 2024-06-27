using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.StoreEntity
{
     public class StoreMangerPermissionRepo<T> : IGenaricRepository<T> where T : StoreManagerPermissions
     { 
        private readonly ApplicationDbContext context;

        public StoreMangerPermissionRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.StoreManagersPermissions.Include(s => s.StoreManager).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.StoreManagersPermissions.Include(s => s.StoreManager).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.StoreManagersPermissions.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.StoreManagersPermissions.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            StoreManagerPermissions entity = await context.StoreManagersPermissions.FindAsync(id);
            entity!.IsDeleted = true;
            context.StoreManagersPermissions.Update(entity);
            await context.SaveChangesAsync();
        }

     }
}
