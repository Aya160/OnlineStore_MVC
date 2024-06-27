using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.AppAccountingCon
{
    public class InvoiceOrderOnlineLineConfig : BaseConfig, IEntityTypeConfiguration<InvoiceOrderOnlineLine>
    {
        public void Configure(EntityTypeBuilder<InvoiceOrderOnlineLine> builder)
        {
            builder.HasOne(i => i.Product).WithMany(p => p.InvoiceOrderOnlineLines)
                .HasForeignKey(i => i.ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(i => i.Order).WithMany(p => p.InvoiceOrderOnlineLines)
                .HasForeignKey(i => i.OrderId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
