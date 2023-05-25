using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaMiaPizzeria.Migrations
{
    /// <inheritdoc />
    public partial class CategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PizzaCategoryId",
                table: "Pizzas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PizzaCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PizzaCategoryId = table.Column<int>(type: "int", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaCategories_PizzaCategories_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "PizzaCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_PizzaCategoryId",
                table: "Pizzas",
                column: "PizzaCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaCategories_CategoriaId",
                table: "PizzaCategories",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_PizzaCategories_PizzaCategoryId",
                table: "Pizzas",
                column: "PizzaCategoryId",
                principalTable: "PizzaCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_PizzaCategories_PizzaCategoryId",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "PizzaCategories");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_PizzaCategoryId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "PizzaCategoryId",
                table: "Pizzas");
        }
    }
}
