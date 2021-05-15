﻿// <auto-generated />
using System;
using Albergue.Administrator.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Albergue.Administrator.Migrations
{
    [DbContext(typeof(AdministrationConsoleDbContext))]
    partial class AdministrationConsoleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Albergue.Administrator.Entities.CategoryEntry", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Albergue.Administrator.Entities.CategoryTranslatableDetailsEntry", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LanguageId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoriesTranslationDetails");
                });

            modelBuilder.Entity("Albergue.Administrator.Entities.LanguageBaseEntry", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Alpha2Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("CategoryTranslatableDetailsEntryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShopItemTranslatableDetailsEntryId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryTranslatableDetailsEntryId");

                    b.HasIndex("ShopItemTranslatableDetailsEntryId");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = "a8d73d39-852a-465b-b56d-a363dcf5f588",
                            Alpha2Code = "EN"
                        },
                        new
                        {
                            Id = "2c406fc6-fada-4b91-8598-7f2a4a58c834",
                            Alpha2Code = "NL"
                        },
                        new
                        {
                            Id = "254af49c-295d-41ea-ad4a-9f2a1b0708f2",
                            Alpha2Code = "PT"
                        },
                        new
                        {
                            Id = "09879122-edf8-490a-b7fb-82da20842307",
                            Alpha2Code = "DE"
                        });
                });

            modelBuilder.Entity("Albergue.Administrator.Entities.LanguageMapEntry", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CategoryTranslatableDetailsEntryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LaguageBaseId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LanguageBaseEntryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShopItemTranslatableDetailsEntryId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryTranslatableDetailsEntryId")
                        .IsUnique();

                    b.HasIndex("LanguageBaseEntryId");

                    b.HasIndex("ShopItemTranslatableDetailsEntryId")
                        .IsUnique();

                    b.ToTable("LanguageMaps");
                });

            modelBuilder.Entity("Albergue.Administrator.Entities.ShopItemEntry", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("ShopItemEntry");
                });

            modelBuilder.Entity("Albergue.Administrator.Entities.ShopItemTranslatableDetailsEntry", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("LanguageId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShopItemId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ShopItemId");

                    b.ToTable("ShopItemTranslatableDetailsEntry");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "6f47773e-04b9-498b-9df2-d0714c74692b",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c76c8293-2d86-4675-a609-c54764ceb68a",
                            Email = "mateusz.wolnica@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "MATEUSZ.WOLNICA@GMAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEG7oB7nbKkc/HwmukK0pQcy+682MJOccCd5/wmuDtNxdALiKdwuQ8nOUX06GtQmWFA==",
                            PhoneNumber = "0048665337563",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "00000000-0000-0000-0000-000000000000",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Albergue.Administrator.Entities.CategoryTranslatableDetailsEntry", b =>
                {
                    b.HasOne("Albergue.Administrator.Entities.CategoryEntry", "Category")
                        .WithMany("TranslatableDetails")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Albergue.Administrator.Entities.LanguageBaseEntry", b =>
                {
                    b.HasOne("Albergue.Administrator.Entities.CategoryTranslatableDetailsEntry", "CategoryTranslatableDetailsEntry")
                        .WithMany()
                        .HasForeignKey("CategoryTranslatableDetailsEntryId");

                    b.HasOne("Albergue.Administrator.Entities.ShopItemTranslatableDetailsEntry", "ShopItemTranslatableDetailsEntry")
                        .WithMany()
                        .HasForeignKey("ShopItemTranslatableDetailsEntryId");

                    b.Navigation("CategoryTranslatableDetailsEntry");

                    b.Navigation("ShopItemTranslatableDetailsEntry");
                });

            modelBuilder.Entity("Albergue.Administrator.Entities.LanguageMapEntry", b =>
                {
                    b.HasOne("Albergue.Administrator.Entities.CategoryTranslatableDetailsEntry", "CategoryTranslatableDetailsEntry")
                        .WithOne("Language")
                        .HasForeignKey("Albergue.Administrator.Entities.LanguageMapEntry", "CategoryTranslatableDetailsEntryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Albergue.Administrator.Entities.LanguageBaseEntry", "LanguageBaseEntry")
                        .WithMany()
                        .HasForeignKey("LanguageBaseEntryId");

                    b.HasOne("Albergue.Administrator.Entities.ShopItemTranslatableDetailsEntry", "ShopItemTranslatableDetailsEntry")
                        .WithOne("Language")
                        .HasForeignKey("Albergue.Administrator.Entities.LanguageMapEntry", "ShopItemTranslatableDetailsEntryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("CategoryTranslatableDetailsEntry");

                    b.Navigation("LanguageBaseEntry");

                    b.Navigation("ShopItemTranslatableDetailsEntry");
                });

            modelBuilder.Entity("Albergue.Administrator.Entities.ShopItemEntry", b =>
                {
                    b.HasOne("Albergue.Administrator.Entities.CategoryEntry", "Category")
                        .WithMany("ShopItems")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Albergue.Administrator.Entities.ShopItemTranslatableDetailsEntry", b =>
                {
                    b.HasOne("Albergue.Administrator.Entities.ShopItemEntry", "ShopItem")
                        .WithMany("TranslatableDetails")
                        .HasForeignKey("ShopItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ShopItem");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Albergue.Administrator.Entities.CategoryEntry", b =>
                {
                    b.Navigation("ShopItems");

                    b.Navigation("TranslatableDetails");
                });

            modelBuilder.Entity("Albergue.Administrator.Entities.CategoryTranslatableDetailsEntry", b =>
                {
                    b.Navigation("Language");
                });

            modelBuilder.Entity("Albergue.Administrator.Entities.ShopItemEntry", b =>
                {
                    b.Navigation("TranslatableDetails");
                });

            modelBuilder.Entity("Albergue.Administrator.Entities.ShopItemTranslatableDetailsEntry", b =>
                {
                    b.Navigation("Language");
                });
#pragma warning restore 612, 618
        }
    }
}
