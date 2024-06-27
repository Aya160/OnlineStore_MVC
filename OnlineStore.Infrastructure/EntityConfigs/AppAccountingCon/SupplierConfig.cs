using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.AppAccountingCon
{
    public class SupplierConfig : BaseConfig, IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasMany(s => s.DetailsInvoices).WithOne(d => d.Supplier);
        }
    }
}
