using Microsoft.EntityFrameworkCore.Migrations;

namespace Albergue.Administrator.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Alpha2Code = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    ShortDescription = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { "4a28e665-a319-438c-952f-0a509e63ad85", "ALL" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Alpha2Code" },
                values: new object[] { "7cfc3035-360e-4a25-921b-124b239b1a7f", "EN" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Alpha2Code" },
                values: new object[] { "24276f81-dc5a-46c5-99a6-9e0364bbcd46", "NL" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Alpha2Code" },
                values: new object[] { "6792b645-08f6-44e1-b645-da42ad957fac", "PT" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Alpha2Code" },
                values: new object[] { "1a11331b-1158-45dc-9009-cdde6956e357", "DE" });

            migrationBuilder.CreateIndex(
                name: "IX_ShopItems_CategoryId",
                table: "ShopItems",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "ShopItems");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
