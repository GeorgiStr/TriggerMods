using Microsoft.EntityFrameworkCore.Migrations;

namespace TriggerMods.Data.Migrations
{
    public partial class FileModelExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Files",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FileSize",
                table: "Files",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Files",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Files");
        }
    }
}
