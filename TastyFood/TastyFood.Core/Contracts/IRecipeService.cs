using TastyFood.Core.Models.RecipeModels.CreateModels;

namespace TastyFood.Core.Contracts
{
    public interface IRecipeService
    {
        // Create action methods
        CreateRecipeViewModel CreateRecipeViewModel(); 
    }
}
