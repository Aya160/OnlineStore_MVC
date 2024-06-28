using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.Entities.General;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.Entities.Users;
using System.Reflection;

namespace OnlineStore.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        //User
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<AdministratorPermission> AdministratorsPermissions { get; set;}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        //Store
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContaintProduct> ContaintProducts { get; set; }
        public DbSet<IncludeCategory> IncludeCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<SaleCategory> SaleCategories { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreManager> StoreManagers { get; set; }
        public DbSet<StoreManagerPermissions> StoreManagersPermissions { get; set; }
        //public DbSet<WorkOnStore> WorkOnStores { get; set; }

        //Shipping
        //public DbSet<Cart> Carts { get; set; }
        public DbSet<DeliverCart> DeliverCarts { get; set; }
        public DbSet<ShippingCompanies> shippingCompanies { get; set; }
        public DbSet<ShippingCompaniesPermissions> ShippingCompaniesPermissions { get; set; }
        public DbSet<StoreReliesOnShippingCompanies> StoreReliesOnShippingCompanies { get; set; }
        //AppAccounting
        public DbSet<DetailsInvoice> DetailsInvoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<InvoiceOrder> InvoiceOrders { get; set; }
        public DbSet<InvoiceOrderLine> InvoiceOrderLines { get; set; }
        public DbSet<InvoiceOrderOnlineLine> InvoiceOrderOnlineLines { get; set; }
        public DbSet<PurchaseBill> purchaseBills { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<BaseEntity>();
        }
    }
}
