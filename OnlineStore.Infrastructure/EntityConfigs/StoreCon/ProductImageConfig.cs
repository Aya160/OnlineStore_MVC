using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.StoreCon
{
    public class ProductImageConfig : BaseConfig, IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasOne(i => i.Product).WithMany(p => p.Images)
                .HasForeignKey(i => i.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
