using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaniEvents123.Data.Migrations
{
    public partial class updatedOrganizateurField101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_OrganisateurId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_OrganisateurId",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "OrganisateurId",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrganisateurId",
                table: "Events",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganisateurId",
                table: "Events",
                column: "OrganisateurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_OrganisateurId",
                table: "Events",
                column: "OrganisateurId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
