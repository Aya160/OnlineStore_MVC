using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.Shipping;

namespace OnlineStore.Infrastructure.EntityConfigs.ShippingCon
{
    public class StoreReliseOnShippingCompaniesConfig : IEntityTypeConfiguration<StoreReliesOnShippingCompanies>
    {
        public void Configure(EntityTypeBuilder<StoreReliesOnShippingCompanies> builder)
        {
            builder.HasKey(sc => new { sc.StoreId, sc.CompanyId });
            builder.HasOne(c => c.Store).WithMany(s => s.ShippingCompanies)
                .HasForeignKey(c => c.StoreId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.ShippingCompanies)
                .WithMany(c => c.StoreReliesOnShippingCompanies)
                .HasForeignKey(s => s.CompanyId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
