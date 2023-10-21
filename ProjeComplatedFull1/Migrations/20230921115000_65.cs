using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeComplatedFull1.Migrations
{
    public partial class _65 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DersAd",
                table: "Not");

            migrationBuilder.DropColumn(
                name: "DersProgramiId",
                table: "Not");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DersAd",
                table: "Not",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DersProgramiId",
                table: "Not",
                type: "int",
                nullable: true);
        }
    }
}
