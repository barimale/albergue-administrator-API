using Albergue.Administrator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albergue.Administrator.Repository
{
    public class CategoryEntryConfiguration : IEntityTypeConfiguration<CategoryEntry>
    {
        public void Configure(EntityTypeBuilder<CategoryEntry> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder.HasMany(dm => dm.ShopItems)
                .WithOne(p => p.Category)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
