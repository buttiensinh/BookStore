using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class giohangvaemail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "NguoiDung",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenDangNhap = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SachID = table.Column<int>(type: "int", nullable: false),
                    SoLuongTrongGio = table.Column<int>(type: "int", nullable: false),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GioHang_Sach_SachID",
                        column: x => x.SachID,
                        principalTable: "Sach",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_SachID",
                table: "GioHang",
                column: "SachID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "NguoiDung");
        }
    }
}
