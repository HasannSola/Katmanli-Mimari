using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LAP.DAL.Migrations
{
    public partial class db_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DtCreateTime",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DtUpdateTime",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InStatus",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DtCreateTime",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DtUpdateTime",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InStatus",
                table: "Customer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DtCreateTime",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DtUpdateTime",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "InStatus",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DtCreateTime",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "DtUpdateTime",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "InStatus",
                table: "Customer");
        }
    }
}
