using Albergue.Administrator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albergue.Administrator.Repository.Database.Configuration
{
    public class ImageEntryConfiguration : IEntityTypeConfiguration<ImageEntry>
    {
        public void Configure(EntityTypeBuilder<ImageEntry> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(p => p.ShopItem)
                .WithMany(pp => pp.Images)
                .HasForeignKey(ppp => ppp.ShopItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.ImageData);
        }
    }
}
