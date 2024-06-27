using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.ShippingCon
{
    public class ShippingCompaniesConfig : BaseConfig,
        IEntityTypeConfiguration<ShippingCompanies>
    {
        public void Configure(EntityTypeBuilder<ShippingCompanies> builder)
        {
            builder.HasMany(c => c.DeliverCarts).WithOne(d => d.Company);
            builder.HasMany(c => c.ShippingCompaniesPermissions)
                .WithOne(p => p.ShippingCompanies).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(c => c.StoreReliesOnShippingCompanies)
                .WithOne(s => s.ShippingCompanies).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
