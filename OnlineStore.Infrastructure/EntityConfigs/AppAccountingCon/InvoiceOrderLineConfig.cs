using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.AppAccountingCon
{
    public class InvoiceOrderLineConfig : BaseConfig, IEntityTypeConfiguration<InvoiceOrderLine>
    {
        public void Configure(EntityTypeBuilder<InvoiceOrderLine> builder)
        {
            builder.HasOne(l => l.InvoiceOrder).WithMany(i => i.InvoiceOrderLines)
                .HasForeignKey(l => l.InvoiceOrderId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(l => l.Product).WithMany(p => p.InvoiceOrderLines)
                .HasForeignKey(l => l.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
