namespace TastyFood.Core.Contracts
{
    using TastyFood.Core.Models.IngredientModels.CreateModels;
    using TastyFood.Core.Models.RecipeModels.CreateModels;

    public interface IRecipeService
    {
        // Create action methods
        CreateRecipeViewModel CreateRecipeViewModel();
        CreateProductViewModel CreateProductViewModel();
    }
}
