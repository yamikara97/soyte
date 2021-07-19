using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HD_proj.Migrations
{
    public partial class datagp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gcngpps",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    Ghichu = table.Column<string>(nullable: true),
                    So = table.Column<string>(nullable: true),
                    Loai = table.Column<string>(nullable: true),
                    idGCN_DKKD = table.Column<string>(nullable: true),
                    idGCN_CCHN = table.Column<string>(nullable: true),
                    Tencoso = table.Column<string>(nullable: true),
                    Truso = table.Column<string>(nullable: true),
                    Diachikinhdoanh = table.Column<string>(nullable: true),
                    Loaihinh = table.Column<string>(nullable: true),
                    Phamvi = table.Column<string>(nullable: true),
                    Ngaycap = table.Column<DateTime>(nullable: false),
                    Ngayhieuluc = table.Column<DateTime>(nullable: false),
                    Trangthai = table.Column<int>(nullable: false),
                    Cmnd = table.Column<string>(nullable: true),
                    Quyetdinh = table.Column<Guid>(nullable: false),
                    Nguoikyduyet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gcngpps", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gcngpps");
        }
    }
}
