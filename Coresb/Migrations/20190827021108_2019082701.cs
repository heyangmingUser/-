using Microsoft.EntityFrameworkCore.Migrations;

namespace Coresb.Migrations
{
    public partial class _2019082701 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Evealtime",
                table: "Movie",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Evealtime",
                table: "Movie");
        }
    }
}
