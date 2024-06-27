using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.AppAccountingCon
{
    public class InvoiceLineConfig : BaseConfig, IEntityTypeConfiguration<InvoiceLine>
    {
        public void Configure(EntityTypeBuilder<InvoiceLine> builder)
        {
            builder.HasOne(i => i.PurchaseBill).WithMany(p => p.InvoiceLines)
                .HasForeignKey(i => i.InvoiceId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(i => i.Product).WithMany(p => p.InvoiceLines)
                .HasForeignKey(i => i.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
