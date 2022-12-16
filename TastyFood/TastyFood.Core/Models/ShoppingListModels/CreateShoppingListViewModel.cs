namespace TastyFood.Core.Models.ShoppingListModels
{
    using System.ComponentModel.DataAnnotations;

    using TastyFood.Core.Models.IngredientModels;

    public class CreateShoppingListViewModel
    {
        public CreateShoppingListViewModel()
        {
            this.Ingredients = new List<IngredientViewModel>();
        }

        [Required]
        public string Name { get; set; } = null!;

        public string OwnerUserId { get; set; } = null!;

        public List<IngredientViewModel> Ingredients { get; set; } = null!;
    }
}
