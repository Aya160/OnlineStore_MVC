using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.Users
{
    public class VendorRepo<T> : IGenaricRepository<T> where T: Vendor
    {
        private readonly ApplicationDbContext context;

        public VendorRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.Vendors.Include(v => v.StoreManager).ToListAsync();
        public IEnumerable<ApplicationUser> GetAllVendorsAsync() =>
           context.Users.Where(u => u.Salary != 0 && u.SSN == string.Empty).ToList();
        public async Task<T> GetById(int id) => (T)await context.Vendors.Include(v => v.StoreManager).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
           context.Vendors.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.Vendors.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Vendor entity = await context.Vendors.FindAsync(id);
            entity!.IsDeleted = true;
            context.Vendors.Update(entity);
            await context.SaveChangesAsync();
        }
 
    }
}
