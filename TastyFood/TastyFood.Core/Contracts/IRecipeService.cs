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
        /// Gets a collection of AllRecipeViewModel which is filtered 
        /// by the User ID
        /// </summary>
        /// <param name="currentUserId">The id of the current User</param>
        /// <returns>returns an IEnumerable collection of type AllRecipeViewModel</returns>
        Task<IEnumerable<AllRecipeViewModel>> GetAllUserOwnRecipesAsync(string currentUserId);

        // Detail action methods

        /// <summary>
        /// Gets the Recipe entity from the database and maps it to the view model
        /// </summary>
        /// <param name="recipeId">the id of the Recipe entity in the database</param>
        /// <returns>returns object of type DetailRecipeViewModel</returns>
        Task<DetailRecipeViewModel> GetRecipeWithIdAsync(int recipeId, string currentUserName);

        /// <summary>
        /// Gets a collection of AllRecipeViewModel with no filter
        /// </summary>
        /// <returns>returns an IEnumerable collection of type AllRecipeViewModel</returns>
        Task<IEnumerable<AllRecipeViewModel>> GetAllRecipesAsync();

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
        Task DeleteSoftAsync(int recipeId);

        /// <summary>
        /// Adding the recipe into the user's favorite list
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        Task AddRecipeToUserFavoritesListAsync(int recipeId, string currentUserId);

        /// <summary>
        /// Gets all the recipe that contains the content of the parameter input
        /// </summary>
        /// <param name="searchBy">parameter of type string that contains the type that the recipe is going to be searched by</param>
        /// <param name="input">parameter of type string that contains the content that the recipe is going to be searched by</param>
        /// <returns>returns an IEnumerable collection of type AllRecipeViewModel</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<AllRecipeViewModel>> GetSearchedRecipesAsync(string title, string input);

        /// <summary>
        /// Gets a recipes collection that is favorites recipes of the user
        /// </summary>
        /// <param name="currentUserId">parameter of type string that contains the curren user id</param>
        /// <returns>IEnumerable collection of type Recipe</returns>
        public Task<IEnumerable<AllRecipeViewModel>> GetUserFavoriteRecipes(string currentUserId);

        /// <summary>
        /// Remove a recipe from user favorite recipes
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        public Task RemoveFromFavorites(int recipeId, string currentUserId);
    }
}
