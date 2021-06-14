using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HD_proj.Migrations
{
    public partial class datasetup2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Ngayky",
                table: "Quyetdinhs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ngayky",
                table: "Quyetdinhs");
        }
    }
}
