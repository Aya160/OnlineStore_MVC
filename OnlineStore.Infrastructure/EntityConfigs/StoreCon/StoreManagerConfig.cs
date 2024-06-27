using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.StoreCon
{
    public class StoreManagerConfig : BaseConfig, IEntityTypeConfiguration<StoreManager>
    {
        public void Configure(EntityTypeBuilder<StoreManager> builder)
        {
            builder.HasOne(sm => sm.Vendor).WithOne(v => v.StoreManager)
                .HasForeignKey<StoreManager>(sm => sm.VenderId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(sm => sm.Store).WithOne(s => s.StoreManager)
                .HasForeignKey<StoreManager>(sm => sm.StoreId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(sm => sm.Permissions).WithOne(p => p.StoreManager);
        }
    }
}
