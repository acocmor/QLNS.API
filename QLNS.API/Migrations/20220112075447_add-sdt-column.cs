using Microsoft.EntityFrameworkCore.Migrations;

namespace QLNS.API.Migrations
{
    public partial class addsdtcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SDT",
                table: "NhanViens",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SDT",
                table: "NhanViens");
        }
    }
}
