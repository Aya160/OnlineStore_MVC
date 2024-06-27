using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.AppAccouting
{
    public class PurchaseBillRepo<T> : IGenaricRepository<T> where T : PurchaseBill
    {
        private readonly ApplicationDbContext context;

        public PurchaseBillRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.purchaseBills.Include(p => p.DetailsInvoice).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.purchaseBills.Include(p => p.DetailsInvoice).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.purchaseBills.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.purchaseBills.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            PurchaseBill entity = await context.purchaseBills.FindAsync(id);
            entity!.IsDeleted = true;
            context.purchaseBills.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
