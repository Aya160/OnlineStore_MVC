using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.StoreEntity
{
    public class ProductImageRepo<T> : IGenaricRepository<T> where T : ProductImage
    {
        private readonly ApplicationDbContext context;

        public ProductImageRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.ProductImages.Include(p => p.Product).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.ProductImages.Include(p => p.Product).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.ProductImages.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.ProductImages.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            ProductImage entity = await context.ProductImages.FindAsync(id);
            entity!.IsDeleted = true;
            context.ProductImages.Update(entity);
            await context.SaveChangesAsync();
        }

    }
}
