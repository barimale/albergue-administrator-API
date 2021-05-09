using Albergue.Administrator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Albergue.Administrator.Repository
{
    public class CategoryEntryConfiguration : IEntityTypeConfiguration<CategoryEntry>
    {
        public void Configure(EntityTypeBuilder<CategoryEntry> builder)
        {
            builder.HasKey(o => o.Id);
        }
    }
}
