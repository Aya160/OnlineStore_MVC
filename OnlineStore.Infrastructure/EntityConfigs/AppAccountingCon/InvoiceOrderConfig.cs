using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.AppAccountingCon
{
    public class InvoiceOrderConfig : BaseConfig, IEntityTypeConfiguration<InvoiceOrder>
    {
        public void Configure(EntityTypeBuilder<InvoiceOrder> builder)
        { 
            builder.HasOne(i => i.Store).WithMany(s => s.InvoiceOrders)
                .HasForeignKey(i => i.StoreId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(i => i.Vendor).WithMany(v => v.InvoiceOrders)
                .HasForeignKey(i => i.VendorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(i => i.InvoiceOrderLines).WithOne(l => l.InvoiceOrder);
        }
    }
}
