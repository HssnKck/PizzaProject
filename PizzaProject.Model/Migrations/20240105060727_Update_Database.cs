using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaProject.Model.Migrations
{
    /// <inheritdoc />
    public partial class Update_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubCategoryDescription",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "SubCategoryPicture",
                table: "SubCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubCategoryDescription",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubCategoryPicture",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
