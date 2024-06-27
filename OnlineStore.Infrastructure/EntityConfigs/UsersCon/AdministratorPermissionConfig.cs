using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.General;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.UsersCon
{
    public class AdministratorPermissionConfig : BaseConfig, IEntityTypeConfiguration<AdministratorPermission>
    {
        public void Configure(EntityTypeBuilder<AdministratorPermission> builder)
        {
            builder.HasOne(p => p.Administrator).WithMany(a => a.Permissions)
                .HasForeignKey(p => p.AdministratorId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
