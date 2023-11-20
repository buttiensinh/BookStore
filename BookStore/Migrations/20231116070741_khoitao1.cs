using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class khoitao1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoVaTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TenDangNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Quyen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NhaSanXuat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhaSanXuat = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaSanXuat", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ThamGia",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaiTro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ViTri = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThamGia", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TheLoai",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTheLoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheLoai", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TinhTrang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoTa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhTrang", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TacGia",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTacGia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TieuSu = table.Column<string>(type: "ntext", nullable: true),
                    ThamGiaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacGia", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TacGia_ThamGia_ThamGiaID",
                        column: x => x.ThamGiaID,
                        principalTable: "ThamGia",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungID = table.Column<int>(type: "int", nullable: false),
                    TinhTrangID = table.Column<int>(type: "int", nullable: false),
                    DienThoaiGiaoHang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DiaChiGiaoHang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgayDatHang = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DonHang_NguoiDung_NguoiDungID",
                        column: x => x.NguoiDungID,
                        principalTable: "NguoiDung",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonHang_TinhTrang_TinhTrangID",
                        column: x => x.TinhTrangID,
                        principalTable: "TinhTrang",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sach",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheLoaiID = table.Column<int>(type: "int", nullable: false),
                    NhaSanXuatID = table.Column<int>(type: "int", nullable: false),
                    TacGiaID = table.Column<int>(type: "int", nullable: false),
                    TenSach = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DonGia = table.Column<int>(type: "int", nullable: false),
                    AnhBia = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sach", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sach_NhaSanXuat_NhaSanXuatID",
                        column: x => x.NhaSanXuatID,
                        principalTable: "NhaSanXuat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sach_TacGia_TacGiaID",
                        column: x => x.TacGiaID,
                        principalTable: "TacGia",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sach_TheLoai_TheLoaiID",
                        column: x => x.TheLoaiID,
                        principalTable: "TheLoai",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonHang_ChiTiet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonHangID = table.Column<int>(type: "int", nullable: false),
                    SachID = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<short>(type: "smallint", nullable: false),
                    DonGia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang_ChiTiet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DonHang_ChiTiet_DonHang_DonHangID",
                        column: x => x.DonHangID,
                        principalTable: "DonHang",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonHang_ChiTiet_Sach_SachID",
                        column: x => x.SachID,
                        principalTable: "Sach",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_NguoiDungID",
                table: "DonHang",
                column: "NguoiDungID");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_TinhTrangID",
                table: "DonHang",
                column: "TinhTrangID");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_ChiTiet_DonHangID",
                table: "DonHang_ChiTiet",
                column: "DonHangID");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_ChiTiet_SachID",
                table: "DonHang_ChiTiet",
                column: "SachID");

            migrationBuilder.CreateIndex(
                name: "IX_Sach_NhaSanXuatID",
                table: "Sach",
                column: "NhaSanXuatID");

            migrationBuilder.CreateIndex(
                name: "IX_Sach_TacGiaID",
                table: "Sach",
                column: "TacGiaID");

            migrationBuilder.CreateIndex(
                name: "IX_Sach_TheLoaiID",
                table: "Sach",
                column: "TheLoaiID");

            migrationBuilder.CreateIndex(
                name: "IX_TacGia_ThamGiaID",
                table: "TacGia",
                column: "ThamGiaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonHang_ChiTiet");

            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "Sach");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "TinhTrang");

            migrationBuilder.DropTable(
                name: "NhaSanXuat");

            migrationBuilder.DropTable(
                name: "TacGia");

            migrationBuilder.DropTable(
                name: "TheLoai");

            migrationBuilder.DropTable(
                name: "ThamGia");
        }
    }
}
