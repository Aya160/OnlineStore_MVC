using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.AppAccouting
{
    public class InvoiceOrderOnlineLineRepo<T> : IGenaricRepository<T> where T : InvoiceOrderOnlineLine
    {
        private readonly ApplicationDbContext context;

        public InvoiceOrderOnlineLineRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.InvoiceOrderOnlineLines.Include(i => i.Order).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.InvoiceOrderOnlineLines.Include(s => s.Order).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.InvoiceOrderOnlineLines.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.InvoiceOrderOnlineLines.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            InvoiceOrderOnlineLine entity = await context.InvoiceOrderOnlineLines.FindAsync(id);
            entity!.IsDeleted = true;
            context.InvoiceOrderOnlineLines.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
