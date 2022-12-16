namespace TastyFood.Core.Models.ShoppingListModels
{
    using TastyFood.Core.Models.IngredientModels;

    public class ShoppingListViewModel
    {
        public ShoppingListViewModel()
        {
            this.Ingredients = new List<IngredientViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<IngredientViewModel> Ingredients { get; set; }
    }
}
