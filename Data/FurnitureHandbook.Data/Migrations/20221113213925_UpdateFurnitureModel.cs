using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurnitureHandbook.Data.Migrations
{
    public partial class UpdateFurnitureModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Furnitures_Edgebands_EdgebandId",
                table: "Furnitures");

            migrationBuilder.DropForeignKey(
                name: "FK_Furnitures_Hardwares_HardwareId",
                table: "Furnitures");

            migrationBuilder.DropForeignKey(
                name: "FK_Furnitures_Textures_TextureId",
                table: "Furnitures");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Furnitures");

            migrationBuilder.AlterColumn<int>(
                name: "TextureId",
                table: "Furnitures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HardwareId",
                table: "Furnitures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EdgebandId",
                table: "Furnitures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Furnitures_Edgebands_EdgebandId",
                table: "Furnitures",
                column: "EdgebandId",
                principalTable: "Edgebands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Furnitures_Hardwares_HardwareId",
                table: "Furnitures",
                column: "HardwareId",
                principalTable: "Hardwares",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Furnitures_Textures_TextureId",
                table: "Furnitures",
                column: "TextureId",
                principalTable: "Textures",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Furnitures_Edgebands_EdgebandId",
                table: "Furnitures");

            migrationBuilder.DropForeignKey(
                name: "FK_Furnitures_Hardwares_HardwareId",
                table: "Furnitures");

            migrationBuilder.DropForeignKey(
                name: "FK_Furnitures_Textures_TextureId",
                table: "Furnitures");

            migrationBuilder.AlterColumn<int>(
                name: "TextureId",
                table: "Furnitures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HardwareId",
                table: "Furnitures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EdgebandId",
                table: "Furnitures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Furnitures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Furnitures_Edgebands_EdgebandId",
                table: "Furnitures",
                column: "EdgebandId",
                principalTable: "Edgebands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Furnitures_Hardwares_HardwareId",
                table: "Furnitures",
                column: "HardwareId",
                principalTable: "Hardwares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Furnitures_Textures_TextureId",
                table: "Furnitures",
                column: "TextureId",
                principalTable: "Textures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
