using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class KhoiTao12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SoLuongTon",
                table: "Sach",
                newName: "SoLuong");

            migrationBuilder.RenameColumn(
                name: "NgayCapNhat",
                table: "Sach",
                newName: "NgayNhap");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SoLuong",
                table: "Sach",
                newName: "SoLuongTon");

            migrationBuilder.RenameColumn(
                name: "NgayNhap",
                table: "Sach",
                newName: "NgayCapNhat");
        }
    }
}
