using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.Users
{ 
    public class AdministratorPermissionRepo<T> : IGenaricRepository<T> where T : AdministratorPermission
    {
        private readonly ApplicationDbContext context;

        public AdministratorPermissionRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.AdministratorsPermissions.Include(a => a.Administrator).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.AdministratorsPermissions.Include(a => a.Administrator).FirstOrDefaultAsync(c => c.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.AdministratorsPermissions.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.AdministratorsPermissions.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await context.AdministratorsPermissions.FindAsync(id);
            entity!.IsDeleted = true;
            context.AdministratorsPermissions.Update(entity);
            await context.SaveChangesAsync();
        }

    }
}

