using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class KhoiTao13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sach_TheLoai_TheLoaiID",
                table: "Sach");

            migrationBuilder.AlterColumn<int>(
                name: "TheLoaiID",
                table: "Sach",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NhaSanXuatID",
                table: "Sach",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sach_NhaSanXuatID",
                table: "Sach",
                column: "NhaSanXuatID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sach_NhaSanXuat_NhaSanXuatID",
                table: "Sach",
                column: "NhaSanXuatID",
                principalTable: "NhaSanXuat",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sach_TheLoai_TheLoaiID",
                table: "Sach",
                column: "TheLoaiID",
                principalTable: "TheLoai",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sach_NhaSanXuat_NhaSanXuatID",
                table: "Sach");

            migrationBuilder.DropForeignKey(
                name: "FK_Sach_TheLoai_TheLoaiID",
                table: "Sach");

            migrationBuilder.DropIndex(
                name: "IX_Sach_NhaSanXuatID",
                table: "Sach");

            migrationBuilder.DropColumn(
                name: "NhaSanXuatID",
                table: "Sach");

            migrationBuilder.AlterColumn<int>(
                name: "TheLoaiID",
                table: "Sach",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sach_TheLoai_TheLoaiID",
                table: "Sach",
                column: "TheLoaiID",
                principalTable: "TheLoai",
                principalColumn: "ID");
        }
    }
}
