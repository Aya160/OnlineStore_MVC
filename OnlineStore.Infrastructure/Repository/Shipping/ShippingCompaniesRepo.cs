using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.Shipping
{
    public class ShippingCompaniesRepo<T> : IGenaricRepository<T> where T : ShippingCompanies
    {
        private readonly ApplicationDbContext context;

        public ShippingCompaniesRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.shippingCompanies.Include(s => s.DeliverCarts).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.shippingCompanies.Include(s => s.DeliverCarts).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.shippingCompanies.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.shippingCompanies.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            ShippingCompanies entity = await context.shippingCompanies.FindAsync(id);
            entity!.IsDeleted = true;
            context.shippingCompanies.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
