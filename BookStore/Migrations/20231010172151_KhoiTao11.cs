using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class KhoiTao11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sach_TheLoai_TheLoaiID1",
                table: "Sach");

            migrationBuilder.DropIndex(
                name: "IX_Sach_TheLoaiID1",
                table: "Sach");

            migrationBuilder.DropColumn(
                name: "NhaSanXuatID",
                table: "Sach");

            migrationBuilder.DropColumn(
                name: "TheLoaiID1",
                table: "Sach");

            migrationBuilder.AlterColumn<int>(
                name: "TheLoaiID",
                table: "Sach",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Sach_TheLoaiID",
                table: "Sach",
                column: "TheLoaiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sach_TheLoai_TheLoaiID",
                table: "Sach",
                column: "TheLoaiID",
                principalTable: "TheLoai",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sach_TheLoai_TheLoaiID",
                table: "Sach");

            migrationBuilder.DropIndex(
                name: "IX_Sach_TheLoaiID",
                table: "Sach");

            migrationBuilder.AlterColumn<string>(
                name: "TheLoaiID",
                table: "Sach",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NhaSanXuatID",
                table: "Sach",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TheLoaiID1",
                table: "Sach",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sach_TheLoaiID1",
                table: "Sach",
                column: "TheLoaiID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Sach_TheLoai_TheLoaiID1",
                table: "Sach",
                column: "TheLoaiID1",
                principalTable: "TheLoai",
                principalColumn: "ID");
        }
    }
}
