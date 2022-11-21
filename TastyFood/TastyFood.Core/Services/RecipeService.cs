namespace TastyFood.Core.Services
{
    using TastyFood.Core.Contracts;
    using TastyFood.Core.Models.IngredientModels.CreateModels;
    using TastyFood.Core.Models.RecipeModels.CreateModels;
    using TastyFood.Infrastructure.Data.Common;

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

        public Task CreateRecipe()
        {

        }
    }
}
