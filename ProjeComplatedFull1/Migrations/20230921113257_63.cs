using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeComplatedFull1.Migrations
{
    public partial class _63 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DersProgramiId",
                table: "Not",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DersProgramiId",
                table: "Not");
        }
    }
}
