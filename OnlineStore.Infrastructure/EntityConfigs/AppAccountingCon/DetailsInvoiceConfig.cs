using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.AppAccountingCon
{
    public class DetailsInvoiceConfig : BaseConfig, IEntityTypeConfiguration<DetailsInvoice>
    {
        public void Configure(EntityTypeBuilder<DetailsInvoice> builder)
        {
            builder.HasOne(d => d.PurchaseBill).WithOne(p => p.DetailsInvoice)
                .HasForeignKey<DetailsInvoice>(d => d.InvoiceId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.Supplier).WithMany(s => s.DetailsInvoices)
                .HasForeignKey(d => d.SupplierId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
