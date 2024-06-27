using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.StoreEntity
{
    public class SaleCategoryRepo<T> : IGenaricRepository<T> where T : SaleCategory
    {
        private readonly ApplicationDbContext context;

        public SaleCategoryRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.SaleCategories.Include(s => s.Store).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.SaleCategories.Include(s => s.Store).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.SaleCategories.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.SaleCategories.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            SaleCategory entity = await context.SaleCategories.FindAsync(id);
            entity!.IsDeleted = true;
            context.SaleCategories.Update(entity);
            await context.SaveChangesAsync();
        }

    }
}
