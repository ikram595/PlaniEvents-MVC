using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaniEvents123.Data.Migrations
{
    public partial class ModificationforeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Events_EventId",
                table: "Tags");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Events_EventId",
                table: "Tags",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Events_EventId",
                table: "Tags");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Tags",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Events_EventId",
                table: "Tags",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId");
        }
    }
}
