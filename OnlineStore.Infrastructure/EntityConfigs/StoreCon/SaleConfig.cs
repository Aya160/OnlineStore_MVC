using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.StoreCon
{
    public class SaleConfig : BaseConfig, IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasMany(s => s.Categories).WithOne(c => c.Sale);
            builder.HasMany(s => s.Products).WithOne(p => p.Sale);
            builder.HasOne(sa => sa.Store).WithMany(s => s.Sales)
                .HasForeignKey(sa => sa.StoreId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
