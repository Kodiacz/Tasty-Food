using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TastyFood.Infrastructure.Migrations
{
    public partial class UserFavoirteRecipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserFavoriteRecipe");

            migrationBuilder.CreateTable(
                name: "ApplicationUserRecipe",
                columns: table => new
                {
                    FavoriteRecipesId = table.Column<int>(type: "int", nullable: false),
                    UsersFavoriteRecipesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRecipe", x => new { x.FavoriteRecipesId, x.UsersFavoriteRecipesId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserRecipe_AspNetUsers_UsersFavoriteRecipesId",
                        column: x => x.UsersFavoriteRecipesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUserRecipe_Recipes_FavoriteRecipesId",
                        column: x => x.FavoriteRecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRecipe_UsersFavoriteRecipesId",
                table: "ApplicationUserRecipe",
                column: "UsersFavoriteRecipesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserRecipe");

            migrationBuilder.CreateTable(
                name: "ApplicationUserFavoriteRecipe",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RecipeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserFavoriteRecipe", x => new { x.ApplicationUserId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserFavoriteRecipe_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ApplicationUserFavoriteRecipe_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserFavoriteRecipe_RecipeId",
                table: "ApplicationUserFavoriteRecipe",
                column: "RecipeId");
        }
    }
}
