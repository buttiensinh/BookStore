using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class khoitao38 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TacGiaID",
                table: "Sach",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sach_TacGiaID",
                table: "Sach",
                column: "TacGiaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sach_TacGia_TacGiaID",
                table: "Sach",
                column: "TacGiaID",
                principalTable: "TacGia",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sach_TacGia_TacGiaID",
                table: "Sach");

            migrationBuilder.DropIndex(
                name: "IX_Sach_TacGiaID",
                table: "Sach");

            migrationBuilder.DropColumn(
                name: "TacGiaID",
                table: "Sach");
        }
    }
}
