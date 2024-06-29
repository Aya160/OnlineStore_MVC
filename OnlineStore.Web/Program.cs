using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Infrastructure.Data;
using OnlineStore.Infrastructure.Repository.AppAccouting;
using OnlineStore.Infrastructure.Repository.Shipping;
using OnlineStore.Infrastructure.Repository.StoreEntity;
using OnlineStore.Infrastructure.Repository.Users;
<<<<<<< HEAD
using System;
=======
>>>>>>> fad783ba2fb2aad4137d5a008bbe5cb758d43cf2

namespace OnlineStore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region Resolve Services
            #region Resolve Identity & Database
            // Database
            builder.Services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
            });
            builder.Services.AddScoped(typeof(DeliverCartRepo<>));
            // Add services to the container.
            builder.Services.AddControllersWithViews();
           //----------------------------------------------
           //Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
            {
                option.Password.RequiredLength = 8;
                option.Password.RequireUppercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.User.RequireUniqueEmail = true;
            })
      .AddEntityFrameworkStores<ApplicationDbContext>();

            #endregion
            builder.Services.AddScoped(typeof(DeliverCartRepo<>));
            builder.Services.AddScoped(typeof(InvoiceLineRepo<>));
            builder.Services.AddScoped(typeof(InvoiceOrderRepo<>));
            builder.Services.AddScoped(typeof(InvoiceOrderLineRepo<>));
            builder.Services.AddScoped(typeof(InvoiceOrderOnlineLineRepo<>));
            builder.Services.AddScoped(typeof(PurchaseBillRepo<>));
            builder.Services.AddScoped(typeof(SupplierRepo<>));
            #endregion

            #region Resolve Shipping Controllers

            #region Resolve Shipping Controllers
            builder.Services.AddScoped(typeof(DeliverCartRepo<>));
            builder.Services.AddScoped(typeof(ShippingCompaniesRepo<>));
            builder.Services.AddScoped(typeof(ShippingCompaniesPermissionsRepo<>));
            #endregion

            #region Resolve StoreControllers
            builder.Services.AddScoped(typeof(CategoryRepo<>));
            builder.Services.AddScoped(typeof(OrderRepo<>));
            builder.Services.AddScoped(typeof(ProductRepo<>));
            builder.Services.AddScoped(typeof(SaleCategoryRepo<>));
            builder.Services.AddScoped(typeof(SaleProductRepo<>));
            builder.Services.AddScoped(typeof(StoreMangerPermissionRepo<>));
            builder.Services.AddScoped(typeof(StoreMangerRepo<>));
            builder.Services.AddScoped(typeof(StoreRepo<>));
            #endregion

            #region Resolve Users Controllers
            builder.Services.AddScoped(typeof(AdministratorRepo<>));
            builder.Services.AddScoped(typeof(AdministratorPermissionRepo<>));
            builder.Services.AddScoped(typeof(CustomerRepo<>));
            builder.Services.AddScoped(typeof(VendorRepo<>));
            builder.Services.AddScoped(typeof(AddressRepo<>));

            #endregion

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
