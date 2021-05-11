using Albergue.Administrator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albergue.Administrator.Repository
{
    public class LanguageEntryConfiguration : IEntityTypeConfiguration<LanguageEntry>
    {
        public void Configure(EntityTypeBuilder<LanguageEntry> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.HasData(
                new LanguageEntry { Alpha2Code = "EN" },
                new LanguageEntry { Alpha2Code = "NL" },
                new LanguageEntry { Alpha2Code = "PT" },
                new LanguageEntry { Alpha2Code = "DE" }
            );
        }
    }
}
