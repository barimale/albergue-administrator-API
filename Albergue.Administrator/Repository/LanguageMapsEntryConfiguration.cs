using Albergue.Administrator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albergue.Administrator.Repository
{
    public class LanguageMapsEntryConfiguration : IEntityTypeConfiguration<LanguageMapEntry>
    {
        public void Configure(EntityTypeBuilder<LanguageMapEntry> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            //builder
            //  .Property(b => b.ShopItemTranslatableDetailsEntryId)
            //  .HasColumnName("ParentId");

            //builder.HasData(
            //    new Language2Entry { Id = Guid.NewGuid().ToString(), Alpha2Code = "EN" },
            //    new Language2Entry { Id = Guid.NewGuid().ToString(), Alpha2Code = "NL" },
            //    new Language2Entry { Id = Guid.NewGuid().ToString(), Alpha2Code = "PT" },
            //    new Language2Entry { Id = Guid.NewGuid().ToString(), Alpha2Code = "DE" }
            //);
        }
    }
}
