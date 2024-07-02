using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.UsersCon
{
    public class VendorConfig : BaseConfig, IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            //builder.HasOne(v => v.Account).WithOne(a => a.Vendor)
            //    .HasForeignKey<Vendor>(v => v.AccountId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(v => v.Store).WithMany(v => v.Vendors)
                .HasForeignKey(w=>w.StoreId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.StoreManager).WithOne(s => s.Vendor);
            builder.HasMany(v => v.InvoiceOrders).WithOne(i => i.Vendor);
        }
    }
}
