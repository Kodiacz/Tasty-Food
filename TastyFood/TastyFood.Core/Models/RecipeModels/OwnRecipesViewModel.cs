namespace TastyFood.Core.Models.RecipeModels
{
    using System.ComponentModel.DataAnnotations;
    using TastyFood.Core.Models.DirectionModels;
    using TastyFood.Core.Models.IngredientModels;

    public class OwnRecipesViewModel
    {
        public OwnRecipesViewModel()
        {
            Ingredients = new List<IngredientViewModel>();
            Directions = new List<DirectionViewModel>();
        }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public string Creator { get; set; }

        public int PreparationTime { get; set; }

        public int CookTime { get; set; }

        public int AdditionalTime { get; set; }

        public int ServingsQuantity { get; set; }

        public IEnumerable<IngredientViewModel> Ingredients { get; set; }

        public IEnumerable<DirectionViewModel> Directions { get; set; }
    }
}
