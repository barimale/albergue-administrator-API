using Albergue.Administrator.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Albergue.Administrator.Repository
{
    public sealed class AdministrationConsoleDbContext : DbContext
    {
        public AdministrationConsoleDbContext(DbContextOptions<AdministrationConsoleDbContext> options)
        : base(options)
        {
            //intentionally left blank
        }

        public DbSet<ShopItemEntry> ShopItems { get; set; }
        public DbSet<CategoryEntry> Categories { get; set; }
        public DbSet<LanguageEntry> Languages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder
                .Entity<LanguageEntry>()
                .HasData(
                    new LanguageEntry { Alpha2Code= "EN" },
                    new LanguageEntry { Alpha2Code= "NL" },
                    new LanguageEntry { Alpha2Code = "PT" },
                    new LanguageEntry { Alpha2Code = "DE" }
                );

            modelBuilder
                .Entity<CategoryEntry>()
                .HasData(
                    new CategoryEntry { Id = Guid.NewGuid().ToString(), Name = "ALL" }
                );
        }
    }
}
