using Albergue.Administrator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albergue.Administrator.Repository
{
    public class ShopItemEntryConfiguration : IEntityTypeConfiguration<ShopItemEntry>
    {
        public void Configure(EntityTypeBuilder<ShopItemEntry> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
