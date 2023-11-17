using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class taocsdl1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaSachID",
                table: "TheLoai");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sach_TheLoai_TheLoaiID1",
                table: "Sach");

            migrationBuilder.DropIndex(
                name: "IX_Sach_TheLoaiID1",
                table: "Sach");

            migrationBuilder.DropColumn(
                name: "TheLoaiID1",
                table: "Sach");

            migrationBuilder.AddColumn<string>(
                name: "MaSachID",
                table: "TheLoai",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
