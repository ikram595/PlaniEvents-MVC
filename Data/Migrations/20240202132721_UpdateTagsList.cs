using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaniEvents123.Data.Migrations
{
    public partial class UpdateTagsList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TagsInput",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagsInput",
                table: "Events");
        }
    }
}
