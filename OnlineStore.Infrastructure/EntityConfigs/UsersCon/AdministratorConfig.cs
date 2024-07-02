using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.General;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.UsersCon
{
    public class AdministratorConfig : BaseConfig, IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            //builder.HasOne(ad => ad.Account).WithOne(ac => ac.Administrator)
            //    .HasForeignKey<Administrator>(ad => ad.AccountId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(a => a.Permissions).WithOne(p => p.Administrator);
            builder.HasMany(a => a.Stores).WithOne(s => s.Administrator);
            builder.HasMany(a => a.PurchaseBills).WithOne(p => p.Administrator);
        }
    }
}
