using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Albergue.Administrator.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesTranslationDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    LanguageId = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesTranslationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriesTranslationDetails_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopItemEntry",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItemEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopItemEntry_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ImageData = table.Column<byte[]>(type: "BLOB", nullable: true),
                    ShopItemId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_ShopItemEntry_ShopItemId",
                        column: x => x.ShopItemId,
                        principalTable: "ShopItemEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopItemTranslatableDetailsEntry",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ShortDescription = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    LanguageId = table.Column<string>(type: "TEXT", nullable: true),
                    ShopItemId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItemTranslatableDetailsEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopItemTranslatableDetailsEntry_ShopItemEntry_ShopItemId",
                        column: x => x.ShopItemId,
                        principalTable: "ShopItemEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Alpha2Code = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryTranslatableDetailsEntryId = table.Column<string>(type: "TEXT", nullable: true),
                    ShopItemTranslatableDetailsEntryId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_CategoriesTranslationDetails_CategoryTranslatableDetailsEntryId",
                        column: x => x.CategoryTranslatableDetailsEntryId,
                        principalTable: "CategoriesTranslationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Languages_ShopItemTranslatableDetailsEntry_ShopItemTranslatableDetailsEntryId",
                        column: x => x.ShopItemTranslatableDetailsEntryId,
                        principalTable: "ShopItemTranslatableDetailsEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LanguageMaps",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    LaguageBaseId = table.Column<string>(type: "TEXT", nullable: true),
                    LanguageBaseEntryId = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryTranslatableDetailsEntryId = table.Column<string>(type: "TEXT", nullable: true),
                    ShopItemTranslatableDetailsEntryId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageMaps_CategoriesTranslationDetails_CategoryTranslatableDetailsEntryId",
                        column: x => x.CategoryTranslatableDetailsEntryId,
                        principalTable: "CategoriesTranslationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LanguageMaps_Languages_LanguageBaseEntryId",
                        column: x => x.LanguageBaseEntryId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LanguageMaps_ShopItemTranslatableDetailsEntry_ShopItemTranslatableDetailsEntryId",
                        column: x => x.ShopItemTranslatableDetailsEntryId,
                        principalTable: "ShopItemTranslatableDetailsEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "42c0d6a9-b045-4f2a-95d9-9e169523f185", 0, "2da8c24a-7706-47ed-8f4b-de73e8ffbb06", "mateusz.wolnica@gmail.com", true, false, null, "MATEUSZ.WOLNICA@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEAX9H+DKGBVWUeu6VohZYSR761JKK0rPNBnw6VnToL+uXEpaqlGSviW+U0q6L0y7JQ==", "0048665337563", true, "00000000-0000-0000-0000-000000000000", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Alpha2Code", "CategoryTranslatableDetailsEntryId", "ShopItemTranslatableDetailsEntryId" },
                values: new object[] { "8f391440-a617-4161-a1cf-c3ac53295560", "EN", null, null });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Alpha2Code", "CategoryTranslatableDetailsEntryId", "ShopItemTranslatableDetailsEntryId" },
                values: new object[] { "6f657f23-f72d-4fbd-880f-de8387a3dc69", "NL", null, null });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Alpha2Code", "CategoryTranslatableDetailsEntryId", "ShopItemTranslatableDetailsEntryId" },
                values: new object[] { "1f7f76e2-8cb1-4664-9135-115d09ecc70a", "PT", null, null });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Alpha2Code", "CategoryTranslatableDetailsEntryId", "ShopItemTranslatableDetailsEntryId" },
                values: new object[] { "b3cb9dc8-f4de-449b-9ca5-32441516f410", "DE", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesTranslationDetails_CategoryId",
                table: "CategoriesTranslationDetails",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ShopItemId",
                table: "Images",
                column: "ShopItemId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageMaps_CategoryTranslatableDetailsEntryId",
                table: "LanguageMaps",
                column: "CategoryTranslatableDetailsEntryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LanguageMaps_LanguageBaseEntryId",
                table: "LanguageMaps",
                column: "LanguageBaseEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageMaps_ShopItemTranslatableDetailsEntryId",
                table: "LanguageMaps",
                column: "ShopItemTranslatableDetailsEntryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_CategoryTranslatableDetailsEntryId",
                table: "Languages",
                column: "CategoryTranslatableDetailsEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_ShopItemTranslatableDetailsEntryId",
                table: "Languages",
                column: "ShopItemTranslatableDetailsEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItemEntry_CategoryId",
                table: "ShopItemEntry",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItemTranslatableDetailsEntry_ShopItemId",
                table: "ShopItemTranslatableDetailsEntry",
                column: "ShopItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "LanguageMaps");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "CategoriesTranslationDetails");

            migrationBuilder.DropTable(
                name: "ShopItemTranslatableDetailsEntry");

            migrationBuilder.DropTable(
                name: "ShopItemEntry");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
