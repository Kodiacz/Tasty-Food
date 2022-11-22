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
        /// Creating a CreateProductViewModel
        /// </summary>
        /// <returns>Returns instance of CreateProductViewModel</returns>
        public CreateProductViewModel CreateProductViewModel()
        {
            return new CreateProductViewModel();
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
                Details = new Detail
                {
                    PreparationTime = model.Details.PreparationTime,
                    CookTime = model.Details.CookTime,
                    AdditionalTime = model.Details.AdditionalTime,
                    ServingsQuantity = model.Details.ServingsQuantity,
                },
                UserOwnerId = currentUserId,
            };

            foreach (var ingredient in model.Ingredients)
            {
                string modelName = ingredient.Product.Name.ToLower();
                string modelCategory = ingredient.Product.Category.Type.ToLower();
                string modelQuantity = ingredient.Quantity.ToLower();

                Product product = new Product();
                Category category = new Category();

                if (this.repo.AllReadonly<Category>().Any(c => c.Type == modelCategory))
                {
                    category = this.repo.AllReadonly<Category>().First(c => c.Type == modelCategory);
                }
                else
                {
                    category.Type = modelCategory;
                    await this.repo.AddAsync(category);
                    await this.repo.SaveChangesAsync();
                }

                if (this.repo.AllReadonly<Product>().Any(p => p.Name == modelName))
                {
                    product = this.repo.AllReadonly<Product>().First(p => p.Name == modelName);
                }
                else
                {
                    product.Name = modelName;
                    product.Category = category;
                    await repo.AddAsync(product);
                    await this.repo.SaveChangesAsync();
                }

                recipe.Ingredients.Add(new Ingredient
                {
                    Product = product,
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
