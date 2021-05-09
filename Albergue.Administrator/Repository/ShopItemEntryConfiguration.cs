using Albergue.Administrator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Albergue.Administrator.Repository
{
    public class ShopItemEntryConfiguration : IEntityTypeConfiguration<ShopItemEntry>
    {
        public void Configure(EntityTypeBuilder<ShopItemEntry> builder)
        {
            builder.HasKey(o => o.Id);
        }
    }
}
