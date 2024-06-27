using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.UsersCon
{
    public class AddressConfig : BaseConfig , IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasOne(ad => ad.Account).WithOne(ac => ac.Address);
            builder.HasMany(a => a.Stores).WithOne(s => s.Address);
            builder.HasOne(a => a.DeliverCart).WithOne(c => c.Address);
        }
    }
}
