using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.StoreEntity
{
    public class SaleProductRepo<T> : IGenaricRepository<T> where T : SaleProduct
    {
        private readonly ApplicationDbContext context;

        public SaleProductRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.SaleProducts.Include(s => s.Store).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.SaleProducts.Include(s => s.Store).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.SaleProducts.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.SaleProducts.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            SaleProduct entity = await context.SaleProducts.FindAsync(id);
            entity!.IsDeleted = true;
            context.SaleProducts.Update(entity);
            await context.SaveChangesAsync();
        }

    }
}
