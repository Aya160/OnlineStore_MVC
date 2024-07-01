using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.StoreCon
{
    public class StoreConfig : BaseConfig, IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.Property(s => s.Name).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(s => s.Location).IsRequired();

            builder.HasOne(s => s.Administrator).WithMany(a => a.Stores)
                .HasForeignKey(s => s.AdministratorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Address).WithMany(a => a.Stores)
                .HasForeignKey(s => s.AddressId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(s => s.Vendors).WithOne(v => v.Store);
            builder.HasOne(s => s.StoreManager).WithOne(sm => sm.Store);
            builder.HasMany(s => s.IncludeCategories).WithOne(i => i.Store);
            builder.HasMany(s => s.ShippingCompanies).WithOne(c => c.Store);
            builder.HasMany(s => s.InvoiceOrders).WithOne(i => i.Store);
            builder.HasMany(s => s.Sales).WithOne(c => c.Store);
        }
    }
}
