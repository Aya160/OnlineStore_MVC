using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.Users
{
    public class AddressRepo<T> : IGenaricRepository<T> where T : Address
    {
        private readonly ApplicationDbContext context;

        public AddressRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.Address.Include(a => a.Stores).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.Address.Include(a => a.Stores).FirstOrDefaultAsync(c => c.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.Address.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.Address.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Address entity = await context.Address.FindAsync(id);
            entity!.IsDeleted = true;
            context.Address.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
