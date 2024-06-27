using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.StoreCon
{
    public class StoreManagerPermissionsConfig : BaseConfig, 
        IEntityTypeConfiguration<StoreManagerPermissions>
    {
        public void Configure(EntityTypeBuilder<StoreManagerPermissions> builder)
        {
            builder.HasOne(p => p.StoreManager).WithMany(sm => sm.Permissions)
                .HasForeignKey(p => p.StoreManagerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
