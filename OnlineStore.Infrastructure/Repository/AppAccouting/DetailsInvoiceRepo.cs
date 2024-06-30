using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.AppAccouting
{
    public class DetailsInvoiceRepo<T> : IGenaricRepository<T> where T : DetailsInvoice
    {
        private readonly ApplicationDbContext context;

        public DetailsInvoiceRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.DetailsInvoices.Include(i => i.Supplier).Include(i => i.PurchaseBill).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.DetailsInvoices.Include(i => i.PurchaseBill).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.DetailsInvoices.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.DetailsInvoices.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            DetailsInvoice entity = await context.DetailsInvoices.FindAsync(id);
            entity!.IsDeleted = true;
            context.DetailsInvoices.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
