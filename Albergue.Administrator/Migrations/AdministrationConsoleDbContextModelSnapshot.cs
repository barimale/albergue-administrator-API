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

                    b.Property<string>("KeyName")
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

            modelBuilder.Entity("Albergue.Administrator.Entities.ImageEntry", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("BLOB");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShopItemId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ShopItemId");

                    b.ToTable("Images");
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

                    b.Property<bool>("Default")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ShopItemTranslatableDetailsEntryId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryTranslatableDetailsEntryId");

                    b.HasIndex("ShopItemTranslatableDetailsEntryId");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = "40c2a201-7aaa-4030-9d42-fd96b53642c2",
                            Alpha2Code = "EN",
                            Default = true
                        },
                        new
                        {
                            Id = "007bc798-2f00-4ea4-913c-eed023d8fb6b",
                            Alpha2Code = "NL",
                            Default = true
                        },
                        new
                        {
                            Id = "cd080995-eb33-472c-8029-f3a8f9455f92",
                            Alpha2Code = "PT",
                            Default = true
                        },
                        new
                        {
                            Id = "b0ed2fb1-a354-4aaa-97ba-67ad7435982d",
                            Alpha2Code = "DE",
                            Default = true
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
                            Id = "98a246b2-3628-4975-82c8-19c75b76345a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c68f8935-a45f-410a-b30a-6134a08b8e63",
                            Email = "mateusz.wolnica@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "MATEUSZ.WOLNICA@GMAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEK9mA4tqDiwHmlt6V6ABUClaU1hHFQQdXmoCczlu9ZXhb2qcS1PtoynrHLmqUVhWrw==",
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
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Albergue.Administrator.Entities.ImageEntry", b =>
                {
                    b.HasOne("Albergue.Administrator.Entities.ShopItemEntry", "ShopItem")
                        .WithMany("Images")
                        .HasForeignKey("ShopItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ShopItem");
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
                        .HasForeignKey("Albergue.Administrator.Entities.LanguageMapEntry", "CategoryTranslatableDetailsEntryId");

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
                    b.Navigation("Images");

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
