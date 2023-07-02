using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyTrungTam.Migrations
{
    /// <inheritdoc />
    public partial class s1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HocSinhs",
                columns: table => new
                {
                    HocSinhId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrinhDoHienTai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocSinhs", x => x.HocSinhId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HocSinhs");
        }
    }
}
