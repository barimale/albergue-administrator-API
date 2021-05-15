using Albergue.Administrator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albergue.Administrator.Repository
{
    public class CategoryTranslatableDetailsEntryConfiguration : IEntityTypeConfiguration<CategoryTranslatableDetailsEntry>
    {
        public void Configure(EntityTypeBuilder<CategoryTranslatableDetailsEntry> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(p => p.Category)
                .WithMany(pp => pp.TranslatableDetails)
                .HasForeignKey(ppp => new { ppp.CategoryId });

            builder
               .HasOne(p => p.Language)
               .WithOne(pp => pp.CategoryTranslatableDetailsEntry)
               .HasForeignKey<LanguageMapEntry>(ppp => ppp.CategoryTranslatableDetailsEntryId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
