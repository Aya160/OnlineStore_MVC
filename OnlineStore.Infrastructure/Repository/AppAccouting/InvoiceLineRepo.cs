using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.AppAccouting
{
    public class InvoiceLineRepo<T> : IGenaricRepository<T> where T : InvoiceLine
    {
        private readonly ApplicationDbContext context;

        public InvoiceLineRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.InvoiceLines.Include(i => i.PurchaseBill).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.InvoiceLines.Include(i => i.PurchaseBill).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.InvoiceLines.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.InvoiceLines.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            InvoiceLine entity = await context.InvoiceLines.FindAsync(id);
            entity!.IsDeleted = true;
            context.InvoiceLines.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
