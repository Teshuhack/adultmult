using Microsoft.EntityFrameworkCore.Migrations;

namespace AdultMult.Migrations
{
    public partial class AddMultUpdateStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "updated",
                table: "mults",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "updated",
                table: "mults");
        }
    }
}
