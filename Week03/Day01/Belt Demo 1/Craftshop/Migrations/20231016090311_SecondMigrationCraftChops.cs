using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Craftshop.Migrations
{
    public partial class SecondMigrationCraftChops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubscribed",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSubscribed",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
