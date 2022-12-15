using TastyFood.Core.Models.RecipeModels;
using TastyFood.Core.Models.ShoppingListModels;
using TastyFood.Infrastructure.Data.Entities;

namespace TastyFood.Core.Contracts
{
    public interface IShoppingListService
    {
        /// <summary>
        /// Binds a ShoppingListViewModel with the properties from DetailRecipeViewModel
        /// that is passed as a parametar
        /// </summary>
        /// <param name="model">parameter object of type DetailRecipeViewModel</param>
        /// <param name="currentUserId">parameter of type string which contains the current user id</param>
        /// <param name="currentUserName">parameter of type string which contains the current user username</param>
        /// <returns>returns object of type CreateShoppingListViewModel</returns>
        public CreateShoppingListViewModel BindShoppingListViewModel(DetailRecipeViewModel model, string currentUserId, string currentUserName);

        /// <summary>
        /// Creates a ShoppingList entity and assigns its properties from the 
        /// model of type CreateShoppingListViewModel that is passed as a parameter
        /// </summary>
        /// <param name="model">parameter object of type CreateShoppingListViewModel</param>
        /// <param name="recipeId">parameter of type int that contains the id of a Recipe entity</param>
        /// <returns></returns>
        public Task CreateShoppintListAsync(CreateShoppingListViewModel model, int recipeId);

        /// <summary>
        /// Gets the owner of the recipe 
        /// </summary>
        /// <param name="recipeId">parameter of type int that contains the id of the Recipe entity</param>
        /// <returns>returns an object of type ApplicationUser</returns>
        public ApplicationUser GetOwnerOfRecipe(int recipeId);

        /// <summary>
        /// Gets the id of the current user ShoppingList
        /// </summary>
        /// <param name="currentUser">parameter of type string that contains the id of the current user</param>
        /// <returns>returns a</returns>
        public int? GetCurrentUserShoppingListId(string currentUser, int currentRecipeId);

        /// <summary>
        /// Deleting by marking the entity as deleted, which means that the property 
        /// IsActive equals false
        /// </summary>
        /// <param name="shoppingListId">parameter of type in which contains the ID of the current recipe</param>
        public void DeleteSoftShoppingList(int? shoppingListId);
    }
}
