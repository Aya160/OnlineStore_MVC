using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.Users
{
    public class AdministratorRepo<T> : IGenaricRepository<T> where T : Administrator
    {
        private readonly ApplicationDbContext context;

        public AdministratorRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.Administrators.Include(a => a.Stores).Include(a => a.Permissions).ToListAsync();
        public IEnumerable<ApplicationUser> GetAllAdminsAsync() =>
            context.Users;
        public async Task<T> GetById(int id) => (T)await context.Administrators.Include(a => a.Stores).FirstOrDefaultAsync(c => c.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.Administrators.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.Administrators.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Administrator entity = await context.Administrators.FindAsync(id);
            entity!.IsDeleted = true;
            context.Administrators.Update(entity);
            await context.SaveChangesAsync();
        }

    }
}
