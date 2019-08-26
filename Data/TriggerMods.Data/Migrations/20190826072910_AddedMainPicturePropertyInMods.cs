using Microsoft.EntityFrameworkCore.Migrations;

namespace TriggerMods.Data.Migrations
{
    public partial class AddedMainPicturePropertyInMods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainPicturePath",
                table: "Mods",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainPicturePath",
                table: "Mods");
        }
    }
}
