using Microsoft.EntityFrameworkCore.Migrations;

namespace Coresb.Migrations
{
    public partial class _2019082702 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Evealtime",
                table: "Movie");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Movie",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Movie",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movie");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Movie",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AddColumn<decimal>(
                name: "Evealtime",
                table: "Movie",
                nullable: true);
        }
    }
}
