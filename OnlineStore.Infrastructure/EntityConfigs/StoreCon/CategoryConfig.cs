using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.StoreCon
{
    public class CategoryConfig : BaseConfig, IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).HasColumnName("CategoryName")
                .HasColumnType("nvarchar(50)").IsRequired();

            builder.HasMany(c => c.IncludeCategories).WithOne(i => i.Category);
            builder.HasMany(c => c.Products).WithOne(p => p.Category);
            builder.HasOne(c => c.Sale).WithMany(s => s.Categories)
                .HasForeignKey(c=>c.SaleId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
