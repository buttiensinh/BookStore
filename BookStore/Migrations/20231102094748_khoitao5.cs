using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class khoitao5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Sach_TheLoaiID",
                table: "Sach");

            migrationBuilder.AlterColumn<string>(
                name: "TheLoaiID",
                table: "Sach",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "NhaSanXuatID",
                table: "Sach",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NhaSanXuatID1",
                table: "Sach",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TheLoaiID1",
                table: "Sach",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sach_NhaSanXuatID1",
                table: "Sach",
                column: "NhaSanXuatID1");

            migrationBuilder.CreateIndex(
                name: "IX_Sach_TheLoaiID1",
                table: "Sach",
                column: "TheLoaiID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Sach_NhaSanXuat_NhaSanXuatID1",
                table: "Sach",
                column: "NhaSanXuatID1",
                principalTable: "NhaSanXuat",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sach_TheLoai_TheLoaiID1",
                table: "Sach",
                column: "TheLoaiID1",
                principalTable: "TheLoai",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sach_NhaSanXuat_NhaSanXuatID1",
                table: "Sach");

            migrationBuilder.DropForeignKey(
                name: "FK_Sach_TheLoai_TheLoaiID1",
                table: "Sach");

            migrationBuilder.DropIndex(
                name: "IX_Sach_NhaSanXuatID1",
                table: "Sach");

            migrationBuilder.DropIndex(
                name: "IX_Sach_TheLoaiID1",
                table: "Sach");

            migrationBuilder.DropColumn(
                name: "NhaSanXuatID1",
                table: "Sach");

            migrationBuilder.DropColumn(
                name: "TheLoaiID1",
                table: "Sach");

            migrationBuilder.AlterColumn<int>(
                name: "TheLoaiID",
                table: "Sach",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "NhaSanXuatID",
                table: "Sach",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Sach_NhaSanXuatID",
                table: "Sach",
                column: "NhaSanXuatID");

            migrationBuilder.CreateIndex(
                name: "IX_Sach_TheLoaiID",
                table: "Sach",
                column: "TheLoaiID");

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
    }
}
