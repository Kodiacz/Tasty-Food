namespace TastyFood.Core.Services
{
    using TastyFood.Core.Contracts;
    using TastyFood.Core.Models.IngredientModels.CreateModels;
    using TastyFood.Core.Models.RecipeModels.CreateModels;
    using TastyFood.Infrastructure.Data;
    using TastyFood.Infrastructure.Data.Common;
    using TastyFood.Infrastructure.Data.Entities;

    public class RecipeService : IRecipeService
    {
        private readonly IRepository repo;

        public RecipeService(IRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Creating a CreateRecipeViewModel
        /// </summary>
        /// <returns>Returns instance of CreateRecipeViewModel</returns>
        public CreateRecipeViewModel CreateRecipeViewModel()
        {
            return new CreateRecipeViewModel();
        }

        /// <summary>
        /// Create a recipe and add it to the database
        /// </summary>
        /// <returns></returns>
        public async Task CreateRecipe(CreateRecipeViewModel model, string currentUserId)
        {
            var recipe = new Recipe()
            {
                Title = model.Title,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PreparationTime = model.PreparationTime,
                CookTime = model.CookTime,
                AdditionalTime = model.AdditionalTime,
                ServingsQuantity = model.ServingsQuantity,
                UserOwnerId = currentUserId,
            };

            foreach (var ingredient in model.Ingredients)
            {
                string modelProduct = ingredient.Product.ToLower();
                string modelQuantity = ingredient.Quantity.ToLower();

                recipe.Ingredients.Add(new Ingredient
                {
                    Product = modelProduct,
                    Quantity = modelQuantity,
                });
            }

            foreach (var modelDirection in model.Directions)
            {
                var direction = new Direction()
                {
                    Step = modelDirection.Step,
                };

                await this.repo.AddAsync(direction);

                recipe.Directions.Add(direction);
            }


            await this.repo.AddAsync(recipe);
            await this.repo.SaveChangesAsync();
        }
    }
}
