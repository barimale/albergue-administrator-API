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
        }
    }
}
