using TastyFood.Core.Models.RecipeModels;
using TastyFood.Core.Models.ShoppingListModels;

namespace TastyFood.Core.Contracts
{
    public interface IShoppingListService
    {
        public CreateShoppingListViewModel CreateShoppingListViewModel(DetailRecipeViewModel model, string currentUserId, string currentUserName);

        public Task CreateShoppintListAsync(CreateShoppingListViewModel model, int recipeId);
    }
}
