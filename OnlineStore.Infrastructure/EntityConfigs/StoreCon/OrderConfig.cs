using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.StoreCon
{
    public class OrderConfig : BaseConfig, IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.RequstDate).IsRequired();

            builder.HasOne(o => o.Customer).WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(o => o.ContaintProducts).WithOne(c => c.Order);
            builder.HasOne(o => o.DeliverCart).WithOne(c => c.Order).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(o => o.InvoiceOrderOnlineLines).WithOne(i => i.Order);
        }
    }
}
