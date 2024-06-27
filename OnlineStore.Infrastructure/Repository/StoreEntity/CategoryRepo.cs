using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.StoreEntity
{
    public class CategoryRepo<T> : IGenaricRepository<T> where T : Category
    {
        private readonly ApplicationDbContext context;

        public CategoryRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.Categories.Include(c => c.SaleCategory).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.Categories.Include(c => c.SaleCategory).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.Categories.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.Categories.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Category entity = await context.Categories.FindAsync(id);
            entity!.IsDeleted = true;
            context.Categories.Update(entity);
            await context.SaveChangesAsync();
        }

    }
}
