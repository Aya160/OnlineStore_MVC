using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.AppAccouting
{
    public class InvoiceOrderLineRepo<T> : IGenaricRepository<T> where T : InvoiceOrderLine
    {
        private readonly ApplicationDbContext context;

        public InvoiceOrderLineRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.InvoiceOrderLines.Include(i => i.InvoiceOrder).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.InvoiceOrderLines.Include(s => s.InvoiceOrder).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.InvoiceOrderLines.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.InvoiceOrderLines.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            InvoiceOrderLine entity = await context.InvoiceOrderLines.FindAsync(id);
            entity!.IsDeleted = true;
            context.InvoiceOrderLines.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
