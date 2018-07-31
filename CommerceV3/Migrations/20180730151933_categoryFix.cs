using Microsoft.EntityFrameworkCore.Migrations;

namespace CommerceV3.Migrations
{
    public partial class categoryFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_Kategori",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Kategori",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Kategori",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kategori",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Kategori",
                table: "Products",
                column: "Kategori");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_Kategori",
                table: "Products",
                column: "Kategori",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
