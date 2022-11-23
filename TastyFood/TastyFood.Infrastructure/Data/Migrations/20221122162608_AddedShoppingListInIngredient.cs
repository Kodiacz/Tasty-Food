using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TastyFood.Infrastructure.Data.Migrations
{
    public partial class AddedShoppingListInIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_ShoppingLists_ShoppingListId",
                table: "Ingredients");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingListId",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_ShoppingLists_ShoppingListId",
                table: "Ingredients",
                column: "ShoppingListId",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_ShoppingLists_ShoppingListId",
                table: "Ingredients");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingListId",
                table: "Ingredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_ShoppingLists_ShoppingListId",
                table: "Ingredients",
                column: "ShoppingListId",
                principalTable: "ShoppingLists",
                principalColumn: "Id");
        }
    }
}
