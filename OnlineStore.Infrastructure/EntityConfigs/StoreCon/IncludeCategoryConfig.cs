using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.StoreEntity;

namespace OnlineStore.Infrastructure.EntityConfigs.StoreCon
{
    public class IncludeCategoryConfig : IEntityTypeConfiguration<IncludeCategory>
    {
        public void Configure(EntityTypeBuilder<IncludeCategory> builder)
        {
            builder.HasKey(i => new { i.StoreId, i.CategoryId });
            builder.HasOne(i => i.Store).WithMany(s => s.IncludeCategories)
                .HasForeignKey(i => i.StoreId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(i => i.Category).WithMany(c => c.IncludeCategories)
                .HasForeignKey(i => i.CategoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
