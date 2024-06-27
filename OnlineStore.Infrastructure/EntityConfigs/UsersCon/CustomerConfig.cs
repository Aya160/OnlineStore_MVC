using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.General;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.UsersCon
{
    public class CustomerConfig : BaseConfig, IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasOne(c => c.Account).WithOne(a => a.Customer)
                .HasForeignKey<Customer>(c => c.AccountId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(c => c.Orders).WithOne(a => a.Customer);
        }
    }
}
