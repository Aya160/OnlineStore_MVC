using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Core.EntityConfigs.ShippingCon
{
    public class ShippingCompaniesPermissionsConfig : BaseConfig,
        IEntityTypeConfiguration<ShippingCompaniesPermissions>
    {
        public void Configure(EntityTypeBuilder<ShippingCompaniesPermissions> builder)
        {
            builder.HasOne(p => p.ShippingCompanies)
                .WithMany(c => c.ShippingCompaniesPermissions)
                .HasForeignKey(p => p.CompanyId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
