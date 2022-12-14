namespace TastyFood.Core.Services
{
    using System.Collections.Generic;
    using TastyFood.Core.Contracts;
    using TastyFood.Core.Models.IngredientModels;
    using TastyFood.Core.Models.RecipeModels;
    using TastyFood.Core.Models.ShoppingListModels;
    using TastyFood.Infrastructure.Data.Common;
    using TastyFood.Infrastructure.Data.Entities;

    public class ShoppingListService : IShoppingListService
    {
        private readonly IRepository repo;

        public ShoppingListService(IRepository repo)
        {
            this.repo = repo;
        }

        public CreateShoppingListViewModel CreateShoppingListViewModel(DetailRecipeViewModel model, string currentUserId, string currentUserName)
        {
            return new CreateShoppingListViewModel
            {
                Name = model.Title,
                Ingredients = model.IngredientsOutput.Select(i => new IngredientViewModel
                {
                    Product = i.Split(" - ")[0],
                    Quantity = i.Split(" - ")[1],
                }).ToList(),
                Username = currentUserName,
                UserId = currentUserId
            };
        }

        public async Task CreateShoppintListAsync(CreateShoppingListViewModel model, int recipeId)
        {
            ShoppingList shoppingEntity = new ShoppingList()
            {
                Name = model.Name,
                UserId = model.UserId,
            };

            var ingredientsEntities = this.repo.All<Ingredient>().Where(i => i.RecipeId == recipeId).ToHashSet();

            foreach (var recipe in ingredientsEntities)
            {
                shoppingEntity.Ingredients.Add(recipe);
            }

            await this.repo.AddAsync(shoppingEntity);
            await this.repo.SaveChangesAsync();
        }

        public ApplicationUser GetOwnerOfRecipe(int recipeId)
        {
            ApplicationUser recipeOwner = this.repo.AllReadonly<ApplicationUser>()
                .Where(au => au.OwnRecipes.Any(or => or.Id == recipeId))
                .FirstOrDefault()!;

            return recipeOwner;
        }
    }
}
