using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.StoreCon
{
    public class SaleProductConfig : BaseConfig ,IEntityTypeConfiguration<SaleProduct>
    {
        public void Configure(EntityTypeBuilder<SaleProduct> builder)
        {
            builder.HasMany(sp => sp.Products).WithOne(p => p.SaleProduct);
            builder.HasOne(sp => sp.Store).WithMany(s => s.SaleProducts)
                .HasForeignKey(sp => sp.StoreId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}