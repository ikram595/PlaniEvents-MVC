using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaniEvents123.Data.Migrations
{
    public partial class AddForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_EventId",
                table: "Tags",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategorieId",
                table: "Events",
                column: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Categories_CategorieId",
                table: "Events",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "CategorieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Events_EventId",
                table: "Tags",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Categories_CategorieId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Events_EventId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_EventId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Events_CategorieId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Events");
        }
    }
}
