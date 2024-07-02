using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.Users
{
    public class CustomerRepo<T> : IGenaricRepository<T> where T : Customer
    {
        private readonly ApplicationDbContext context;

        public CustomerRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.Customers.Include(c => c.Orders).ToListAsync();

		// Where is the Table between Orders & Customers, isn't the relation M to M

		public IEnumerable<ApplicationUser> GetAllCustomersAsync() =>
		   context.Users.Where(u => u.Salary== 0 && u.SSN == string.Empty).ToList();
		public async Task<T> GetById(int id) => (T)await context
            .Customers.FindAsync(id); //------------------------ Include()
        public async Task CreateAsync(T entity)
        {
            context.Customers.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.Customers.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await context.Customers.FindAsync(id);
            entity!.IsDeleted = true;
            context.Customers.Update(entity);
            await context.SaveChangesAsync();
        }

    }
}
