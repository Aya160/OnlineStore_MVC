using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.StoreEntity
{
    public class ProductRepo<T> : IGenaricRepository<T> where T : Product
    {
        private readonly ApplicationDbContext context;

        public ProductRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.Products.Include(p => p.SaleProduct).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.Products.Include(p => p.SaleProduct).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.Products.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.Products.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Product entity = await context.Products.FindAsync(id);
            entity!.IsDeleted = true;
            context.Products.Update(entity);
            await context.SaveChangesAsync();
        }

    }
}
