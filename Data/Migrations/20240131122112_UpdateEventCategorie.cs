using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaniEvents123.Data.Migrations
{
    public partial class UpdateEventCategorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Categories_CategorieId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Events_CategorieId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Categorie",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categorie",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomCategorie = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategorieId);
                });

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
        }
    }
}
