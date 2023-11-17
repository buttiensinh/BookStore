using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class KhoiTao15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sach_ThamGia_ThamGiaID",
                table: "Sach");

            migrationBuilder.DropIndex(
                name: "IX_Sach_ThamGiaID",
                table: "Sach");

            migrationBuilder.DropColumn(
                name: "ThamGiaID",
                table: "Sach");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThamGiaID",
                table: "Sach",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sach_ThamGiaID",
                table: "Sach",
                column: "ThamGiaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sach_ThamGia_ThamGiaID",
                table: "Sach",
                column: "ThamGiaID",
                principalTable: "ThamGia",
                principalColumn: "ID");
        }
    }
}
