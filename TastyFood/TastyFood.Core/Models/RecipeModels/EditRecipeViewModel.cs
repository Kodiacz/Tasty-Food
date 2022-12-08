namespace TastyFood.Core.Models.RecipeModels
{
    using System.ComponentModel.DataAnnotations;

    using TastyFood.Core.Models.DirectionModels;
    using TastyFood.Core.Models.IngredientModels;

    public class EditRecipeViewModel
    {
        public EditRecipeViewModel()
        {
            Ingredients = new List<IngredientViewModel>();
            DeletedIngredients = new List<IngredientViewModel>();
            Directions = new List<DirectionViewModel>();
            DeletedDirections = new List<DirectionViewModel>();
        }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public int PreparationTime { get; set; }

        [Required]
        public int CookTime { get; set; }

        [Required]
        public int AdditionalTime { get; set; }

        [Required]
        public int ServingsQuantity { get; set; }

        public List<IngredientViewModel> Ingredients { get; set; }

        public List<IngredientViewModel> DeletedIngredients { get; set; }

        public List<DirectionViewModel> Directions { get; set; }

        public List<DirectionViewModel> DeletedDirections { get; set; }
    }
}
