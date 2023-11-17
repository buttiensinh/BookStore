using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class KhoiTao10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_KhachHang_KhachHangID",
                table: "DonHang");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropIndex(
                name: "IX_DonHang_KhachHangID",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "KhachHangID",
                table: "DonHang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KhachHangID",
                table: "DonHang",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    HoVaTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaiKhoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_KhachHangID",
                table: "DonHang",
                column: "KhachHangID");

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_KhachHang_KhachHangID",
                table: "DonHang",
                column: "KhachHangID",
                principalTable: "KhachHang",
                principalColumn: "ID");
        }
    }
}
