using Albergue.Administrator.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Albergue.Administrator.Repository
{
    public sealed class AdministrationConsoleDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
