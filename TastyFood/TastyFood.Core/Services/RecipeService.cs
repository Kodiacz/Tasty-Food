namespace TastyFood.Core.Services
{
    using TastyFood.Core.Contracts;
    using TastyFood.Core.Models.IngredientModels.CreateModels;
    using TastyFood.Core.Models.RecipeModels.CreateModels;
    using TastyFood.Infrastructure.Data;

    public class RecipeService : IRecipeService
    {
        private readonly TastyFoodDbContext dbContext;

        public RecipeService(TastyFoodDbContext dbContext)
        {
            this.dbContext = dbContext;
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
