using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.StoreEntity
{
    public class SaleRepo<T> : IGenaricRepository<T> where T : Sale
    {
        private readonly ApplicationDbContext context;

        public SaleRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.Sales.Include(s => s.Store).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.Sales.Include(s => s.Store).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.Sales.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.Sales.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Sale entity = await context.Sales.FindAsync(id);
            entity!.IsDeleted = true;
            context.Sales.Update(entity);
            await context.SaveChangesAsync();
        }

    }
}
