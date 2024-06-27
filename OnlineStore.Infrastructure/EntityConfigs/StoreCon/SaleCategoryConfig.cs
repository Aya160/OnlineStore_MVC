using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.StoreCon
{
    public class SaleCategoryConfig : BaseConfig, IEntityTypeConfiguration<SaleCategory>
    {
        public void Configure(EntityTypeBuilder<SaleCategory> builder)
        {
            builder.HasMany(sc => sc.Categories).WithOne(c => c.SaleCategory);
            builder.HasOne(sc => sc.Store).WithMany(s => s.SaleCategories)
                .HasForeignKey(sc => sc.StoreId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
