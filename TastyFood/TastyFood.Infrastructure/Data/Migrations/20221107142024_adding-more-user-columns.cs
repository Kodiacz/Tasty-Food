using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TastyFood.Infrastructure.Data.Migrations
{
    public partial class addingmoreusercolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ShoppingLists",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Recipes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingListId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_UserId",
                table: "ShoppingLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RecipeId",
                table: "AspNetUsers",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ShoppingListId",
                table: "AspNetUsers",
                column: "ShoppingListId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Recipes_RecipeId",
                table: "AspNetUsers",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ShoppingLists_ShoppingListId",
                table: "AspNetUsers",
                column: "ShoppingListId",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_AspNetUsers_UserId",
                table: "Recipes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLists_AspNetUsers_UserId",
                table: "ShoppingLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Recipes_RecipeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShoppingLists_ShoppingListId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_AspNetUsers_UserId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLists_AspNetUsers_UserId",
                table: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_UserId",
                table: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RecipeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ShoppingListId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShoppingListId",
                table: "AspNetUsers");
        }
    }
}
