namespace TastyFood.Core.Contracts
{
    using System.Threading.Tasks;
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
        Task CreateRecipeAsync(CreateRecipeViewModel model, string currentUserId);

        // MyRecipe action methods

        /// <summary>
        /// Creates a collection of AllOwnRecipeViewModel
        /// </summary>
        /// <param name="currentUserId">The id of the current User</param>
        /// <returns>returns IEnumerable<OwnRecipesViewModel></returns>
        Task<IEnumerable<AllOwnRecipeViewModel>> GetAllUserOwnRecipesAsync(string currentUserId);

        // Detail action methods

        /// <summary>
        /// Gets the Recipe entity from the database and maps it to the view model
        /// </summary>
        /// <param name="recipeId">the id of the Recipe entity in the database</param>
        /// <returns>DetailRecipeViewModel with all the needed data</returns>
        Task<DetailRecipeViewModel> GetRecipeWithIdAsync(int recipeId, string currentUserName);
    }
}
