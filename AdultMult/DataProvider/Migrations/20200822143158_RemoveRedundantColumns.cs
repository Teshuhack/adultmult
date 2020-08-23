using Microsoft.EntityFrameworkCore.Migrations;

namespace AdultMult.Migrations
{
    public partial class RemoveRedundantColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "englishcaption",
                table: "mults");

            migrationBuilder.DropColumn(
                name: "thumbnail",
                table: "mults");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "englishcaption",
                table: "mults",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "thumbnail",
                table: "mults",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
