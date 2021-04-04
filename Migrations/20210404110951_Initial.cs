using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ItemApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: true),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    SubContent = table.Column<string>(type: "TEXT", nullable: true),
                    SubTitle = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Author", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[] { 1, "Author1", "Content1", new DateTime(2021, 4, 4, 20, 9, 51, 420, DateTimeKind.Local).AddTicks(1739), "Title1", null });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Author", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[] { 2, "Author2", "Content2", new DateTime(2021, 4, 4, 20, 9, 51, 421, DateTimeKind.Local).AddTicks(3466), "Title2", null });

            migrationBuilder.InsertData(
                table: "SubItems",
                columns: new[] { "Id", "Author", "CreatedAt", "ItemId", "SubContent", "SubTitle", "UpdatedAt" },
                values: new object[] { 1, "SubAuthor1", new DateTime(2021, 4, 4, 20, 9, 51, 422, DateTimeKind.Local).AddTicks(2261), 1, "SubContent1", "SubTitle1", null });

            migrationBuilder.InsertData(
                table: "SubItems",
                columns: new[] { "Id", "Author", "CreatedAt", "ItemId", "SubContent", "SubTitle", "UpdatedAt" },
                values: new object[] { 2, "SubAuthor2", new DateTime(2021, 4, 4, 20, 9, 51, 422, DateTimeKind.Local).AddTicks(2923), 2, "SubContent2", "SubTitle2", null });

            migrationBuilder.CreateIndex(
                name: "IX_SubItems_ItemId",
                table: "SubItems",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubItems");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
