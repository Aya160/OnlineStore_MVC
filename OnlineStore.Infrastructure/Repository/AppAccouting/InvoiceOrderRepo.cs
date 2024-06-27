using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Infrastructure.Repository.AppAccouting
{
    public class InvoiceOrderRepo<T> : IGenaricRepository<T> where T : InvoiceOrder
    {
        private readonly ApplicationDbContext context;

        public InvoiceOrderRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.InvoiceOrders.Include(i => i.Store).Include(i => i.Vendor).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.InvoiceOrders.Include(i => i.Store).Include(i => i.Vendor).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.InvoiceOrders.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.InvoiceOrders.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            InvoiceOrder entity = await context.InvoiceOrders.FindAsync(id);
            entity!.IsDeleted = true;
            context.InvoiceOrders.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
