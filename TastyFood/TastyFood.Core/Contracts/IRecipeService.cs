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

        /// <summary>
        /// Creating an EditRecipeViewModel and assigning the proper values to it
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns>Returning EditRecipeViewModel</returns>
        Task<EditRecipeViewModel> CreateEditRecipeViewModelAsync(int recipeId);

        /// <summary>
        /// Updating the Recipe entity in the database with the EditRecipeViewModel
        /// </summary>
        /// <param name="model">RecipeViewModel variable</param>
        /// <param name="recipeId">Recipe id in the database</param>
        /// <returns></returns>
        Task UpdateRecipeAsync(EditRecipeViewModel model, int recipeId);

        /// <summary>
        /// Marks the entity as deleted but it doesn't really deletes the entity from the database
        /// </summary>
        /// <param name="recipeId">integer type that represents the id of the Recipe entity</param>
        /// <returns></returns>
        Task DeleteSoft(int recipeId);
    }
}
