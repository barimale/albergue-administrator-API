using Albergue.Administrator.Entities;
using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CategoryEntryConfiguration());
            //modelBuilder.ApplyConfiguration(new ShopItemEntryConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
