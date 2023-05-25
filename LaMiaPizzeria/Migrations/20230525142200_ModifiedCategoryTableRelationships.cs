using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaMiaPizzeria.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedCategoryTableRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaCategories_PizzaCategories_CategoriaId",
                table: "PizzaCategories");

            migrationBuilder.DropIndex(
                name: "IX_PizzaCategories_CategoriaId",
                table: "PizzaCategories");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "PizzaCategories");

            migrationBuilder.DropColumn(
                name: "PizzaCategoryId",
                table: "PizzaCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "PizzaCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PizzaCategoryId",
                table: "PizzaCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PizzaCategories_CategoriaId",
                table: "PizzaCategories",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaCategories_PizzaCategories_CategoriaId",
                table: "PizzaCategories",
                column: "CategoriaId",
                principalTable: "PizzaCategories",
                principalColumn: "Id");
        }
    }
}
