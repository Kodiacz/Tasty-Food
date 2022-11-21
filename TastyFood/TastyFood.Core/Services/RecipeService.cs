namespace TastyFood.Core.Services
{
    using TastyFood.Core.Contracts;
    using TastyFood.Core.Models.IngredientModels.CreateModels;
    using TastyFood.Core.Models.RecipeModels.CreateModels;
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

        public Task CreateRecipe(CreateRecipeViewModel model, string currentUserId)
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
            };

            foreach (var item in model.Ingredients)
            {
                string name = item.Product.Name.ToLower();
                string category = item.Product.Category.Type.ToLower();
                

                if (repo.All<Product>().Any(p => p)
            }
        }
    }
}
