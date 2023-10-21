using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeComplatedFull1.Migrations
{
    public partial class _64 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DersAd",
                table: "Not",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DersAd",
                table: "Not");
        }
    }
}
