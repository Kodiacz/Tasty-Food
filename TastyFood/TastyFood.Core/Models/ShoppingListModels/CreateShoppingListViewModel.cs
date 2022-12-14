namespace TastyFood.Core.Models.ShoppingListModels
{
    using TastyFood.Core.Models.IngredientModels;

    public class CreateShoppingListViewModel
    {
        public CreateShoppingListViewModel()
        {
            this.Ingredients = new List<IngredientViewModel>();
        }

        public string Name { get; set; } = null!;

        public string UserId { get; set; } = null!;

        public string Username { get; set; } = null!;

        public List<IngredientViewModel> Ingredients { get; set; } = null!;
    }
}
