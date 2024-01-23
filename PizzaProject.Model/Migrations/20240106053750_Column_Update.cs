using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaProject.Model.Migrations
{
    /// <inheritdoc />
    public partial class Column_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategories_PizzaCategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "PizzaCategoryId",
                table: "Products",
                newName: "SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_PizzaCategoryId",
                table: "Products",
                newName: "IX_Products_SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCategories_SubCategoryId",
                table: "Products",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategories_SubCategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "SubCategoryId",
                table: "Products",
                newName: "PizzaCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SubCategoryId",
                table: "Products",
                newName: "IX_Products_PizzaCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCategories_PizzaCategoryId",
                table: "Products",
                column: "PizzaCategoryId",
                principalTable: "SubCategories",
                principalColumn: "ID");
        }
    }
}
