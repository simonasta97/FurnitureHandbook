using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurnitureHandbook.Data.Migrations
{
    public partial class UpdateDocumentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Documents");
        }
    }
}
