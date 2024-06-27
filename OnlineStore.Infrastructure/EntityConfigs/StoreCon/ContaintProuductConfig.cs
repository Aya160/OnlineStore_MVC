using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.StoreEntity;

namespace OnlineStore.Infrastructure.EntityConfigs.StoreCon
{
    public class ContaintProuductConfig : IEntityTypeConfiguration<ContaintProduct>
    {
        public void Configure(EntityTypeBuilder<ContaintProduct> builder)
        {
            builder.HasKey(c => new { c.ProductId, c.OrderId });
            builder.HasOne(c => c.Product).WithMany(p => p.ContaintProducts)
                .HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Order).WithMany(o => o.ContaintProducts)
                .HasForeignKey(c => c.OrderId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}