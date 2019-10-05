using Microsoft.EntityFrameworkCore.Migrations;

namespace LAP.DAL.Migrations
{
    public partial class db3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InStatus",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StDescription",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InStatus",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StDescription",
                table: "User");
        }
    }
}
