using Albergue.Administrator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Albergue.Administrator.Repository
{
    public class LanguageCategoryEntryConfiguration : IEntityTypeConfiguration<LanguageCategoryEntry>
    {
        public void Configure(EntityTypeBuilder<LanguageCategoryEntry> builder)
        {
            //builder.HasKey(o => o.Id);
            //builder
            //    .Property(p => p.Id)
            //    .ValueGeneratedOnAdd();

            builder
               .Property(b => b.CategoryTranslatableDetailsEntryId)
               .HasColumnName("ParentId");

            //builder.HasData(
            //    new LanguageShopItemEntry { Id = Guid.NewGuid().ToString(), Alpha2Code = "EN" },
            //    new LanguageShopItemEntry { Id = Guid.NewGuid().ToString(), Alpha2Code = "NL" },
            //    new LanguageShopItemEntry { Id = Guid.NewGuid().ToString(), Alpha2Code = "PT" },
            //    new LanguageShopItemEntry { Id = Guid.NewGuid().ToString(), Alpha2Code = "DE" }
            //);
        }
    }
}
