namespace TriggerMods.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class MorePropertiesInPrivateMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Quote",
                table: "PrivateMessages",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ReceiverHide",
                table: "PrivateMessages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SerderHide",
                table: "PrivateMessages",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quote",
                table: "PrivateMessages");

            migrationBuilder.DropColumn(
                name: "ReceiverHide",
                table: "PrivateMessages");

            migrationBuilder.DropColumn(
                name: "SerderHide",
                table: "PrivateMessages");
        }
    }
}
