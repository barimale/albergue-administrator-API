using Albergue.Administrator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Albergue.Administrator.Repository.Database.Configuration
{
    public class LanguageBaseEntryConfiguration : IEntityTypeConfiguration<LanguageBaseEntry>
    {
        public void Configure(EntityTypeBuilder<LanguageBaseEntry> builder)
        {
            builder.HasKey(o => o.Id);
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.HasData(
                new LanguageBaseEntry { Id = Guid.NewGuid().ToString(), Alpha2Code = "EN" },
                new LanguageBaseEntry { Id = Guid.NewGuid().ToString(), Alpha2Code = "NL" },
                new LanguageBaseEntry { Id = Guid.NewGuid().ToString(), Alpha2Code = "PT" },
                new LanguageBaseEntry { Id = Guid.NewGuid().ToString(), Alpha2Code = "DE" }
            );
        }
    }
}
