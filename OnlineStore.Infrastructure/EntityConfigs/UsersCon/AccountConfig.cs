using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.General;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.UsersCon
{
    public class AccountConfig : BaseConfig, IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasBaseType<BaseEntity>();
            builder.HasOne(ac => ac.Address).WithOne(ad => ad.Account).
                HasForeignKey<Account>(ac => ac.AddressId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(ac => ac.Customer).WithOne(c => c.Account);
            builder.HasOne(ac => ac.Vendor).WithOne(v => v.Account);
            builder.HasOne(ac => ac.Administrator).WithOne(ad => ad.Account);
        }
    }
}
