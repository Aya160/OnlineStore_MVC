using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.AppAccouting
{
    public class SupplierRepo<T> : IGenaricRepository<T> where T : Supplier
    {
        private readonly ApplicationDbContext context;

        public SupplierRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.Suppliers.Include(s => s.DetailsInvoices).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.Suppliers.Include(s => s.DetailsInvoices).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.Suppliers.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.Suppliers.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Supplier entity = await context.Suppliers.FindAsync(id);
            entity!.IsDeleted = true;
            context.Suppliers.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
