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

        public CreateProductViewModel CreateProductViewModel()
        {
            return new CreateProductViewModel();
        }

        public CreateRecipeViewModel CreateRecipeViewModel()
        {
            return new CreateRecipeViewModel();
        }


    }
}
