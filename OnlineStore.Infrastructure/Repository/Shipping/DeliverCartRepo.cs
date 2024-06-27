using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.Shipping
{
    public class DeliverCartRepo<T> : IGenaricRepository<T> where T : DeliverCart
    {
        private readonly ApplicationDbContext context;

        public DeliverCartRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.DeliverCarts.Include(d => d.Order).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.DeliverCarts.Include(d => d.Order).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.DeliverCarts.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.DeliverCarts.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            DeliverCart entity = await context.DeliverCarts.FindAsync(id);
            entity!.IsDeleted = true;
            context.DeliverCarts.Update(entity);
            await context.SaveChangesAsync();
        }

    }
}
