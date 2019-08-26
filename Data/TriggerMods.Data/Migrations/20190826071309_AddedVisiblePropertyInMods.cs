using Microsoft.EntityFrameworkCore.Migrations;

namespace TriggerMods.Data.Migrations
{
    public partial class AddedVisiblePropertyInMods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalDownlaodCount",
                table: "Mods",
                newName: "TotalDownloadCount");

            migrationBuilder.RenameColumn(
                name: "TotalDownlaodCount",
                table: "Games",
                newName: "TotalDownloadCount");

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "Mods",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visible",
                table: "Mods");

            migrationBuilder.RenameColumn(
                name: "TotalDownloadCount",
                table: "Mods",
                newName: "TotalDownlaodCount");

            migrationBuilder.RenameColumn(
                name: "TotalDownloadCount",
                table: "Games",
                newName: "TotalDownlaodCount");
        }
    }
}
