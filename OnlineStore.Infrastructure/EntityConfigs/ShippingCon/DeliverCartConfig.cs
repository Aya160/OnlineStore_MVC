using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.Shipping;

namespace OnlineStore.Infrastructure.EntityConfigs.ShippingCon
{
    public class DeliverCartConfig : IEntityTypeConfiguration<DeliverCart>
    {
        public void Configure(EntityTypeBuilder<DeliverCart> builder)
        {
            builder.HasOne(d => d.Address).WithOne(a => a.DeliverCart)
                .HasForeignKey<DeliverCart>(d => d.AddersId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.Order).WithOne(o => o.DeliverCart)
                .HasForeignKey<DeliverCart>(d => d.OrderId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.Company).WithMany(c => c.DeliverCarts)
                .HasForeignKey(d => d.CompanyId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
