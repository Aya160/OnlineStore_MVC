using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.AppAccountingCon
{
    public class PurchaseBillConfig : BaseConfig, IEntityTypeConfiguration<PurchaseBill>
    {
        public void Configure(EntityTypeBuilder<PurchaseBill> builder)
        {
            builder.HasOne(p => p.Administrator).WithMany(a => a.PurchaseBills)
                .HasForeignKey(p => p.AdministratorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.DetailsInvoice).WithOne(d => d.PurchaseBill);
            builder.HasMany(p => p.InvoiceLines).WithOne(i => i.PurchaseBill);
        }
    }
}
