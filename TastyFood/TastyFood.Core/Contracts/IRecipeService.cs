namespace TastyFood.Core.Contracts
{
    using System.Threading.Tasks;
    using TastyFood.Core.Models.IngredientModels.CreateModels;
    using TastyFood.Core.Models.RecipeModels.CreateModels;

    public interface IRecipeService
    {
        // Create action methods

        /// <summary>
        /// Creating a CreateRecipeViewModel
        /// </summary>
        /// <returns>Returns instance of CreateRecipeViewModel</returns>
        CreateRecipeViewModel CreateRecipeViewModel();

        /// <summary>
        /// Creating a CreateProductViewModel
        /// </summary>
        /// <returns>Returns instance of CreateProductViewModel</returns>
        CreateProductViewModel CreateProductViewModel();

        /// <summary>
        /// Create a recipe and add it to the database
        /// </summary>
        /// <returns></returns>
        Task CreateRecipe(CreateRecipeViewModel model, string currentUserId);

        //Task GetRecipes(GetRecipeViewModel model)
        //{

        //}
    }
}
