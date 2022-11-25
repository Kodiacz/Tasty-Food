namespace TastyFood.Core.Contracts
{
    using System.Threading.Tasks;
    using TastyFood.Core.Models.IngredientModels.CreateModels;
    using TastyFood.Core.Models.RecipeModels;

    public interface IRecipeService
    {
        // Create action methods

        /// <summary>
        /// Creates a CreateRecipeViewModel
        /// </summary>
        /// <returns>Returns instance of CreateRecipeViewModel</returns>
        CreateRecipeViewModel CreateRecipeViewModel();

        /// <summary>
        /// Create a recipe and add it to the database
        /// </summary>
        /// <returns></returns>
        Task CreateRecipe(CreateRecipeViewModel model, string currentUserId);

        /// <summary>
        /// Creates a OwnRecipesViewModel();
        /// </summary>
        /// <returns>returns IEnumerable<OwnRecipesViewModel></returns>
        IEnumerable<OwnRecipesViewModel> GetAllUserOwnRecipes(string currentUserId, string currentUserName);
    }
}
