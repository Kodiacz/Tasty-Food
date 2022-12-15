namespace TastyFood.Core.Models.RecipeModels
{
    using System.ComponentModel.DataAnnotations;

    using TastyFood.Core.Models.DirectionModels;
    using TastyFood.Core.Models.IngredientModels;
    using static TastyFood.Infrastructure.Data.DataConstants.RecipeConstants;

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
        [Range(PreparationTimeMinLength, PreparationTimeMaxLength)]
        public int PreparationTime { get; set; }

        [Required]
        [Range(CookTimeMinLength, CookTimeMaxLength)]
        public int CookTime { get; set; }

        [Required]
        [Range(AdditionalTimeMinLength, AdditionalTimeMaxLength)]
        public int AdditionalTime { get; set; }

        [Required]
        [Range(ServingsQuantityMinLength, ServingsQuantityMaxLength)]
        public int ServingsQuantity { get; set; }

        public List<IngredientViewModel> Ingredients { get; set; }

        public List<IngredientViewModel> DeletedIngredients { get; set; }

        public List<DirectionViewModel> Directions { get; set; }

        public List<DirectionViewModel> DeletedDirections { get; set; }
    }
}
