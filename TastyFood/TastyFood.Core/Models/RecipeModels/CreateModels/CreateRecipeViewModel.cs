namespace TastyFood.Core.Models.RecipeModels.CreateModels
{
    using System.ComponentModel.DataAnnotations;
    using TastyFood.Core.Models.DirectionModels.CreateModels;
    using TastyFood.Core.Models.IngredientModels.CreateModels;
    using static TastyFood.Infrastructure.Data.DataConstants.RecipeConstants;

    public class CreateRecipeViewModel
    {
        public CreateRecipeViewModel()
        {
            this.Ingredients = new List<CreateIngredientViewModel>();
            this.Directions = new List<CreateDirectionViewModel>();
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

        public IEnumerable<CreateIngredientViewModel> Ingredients { get; set; }

        public IEnumerable<CreateDirectionViewModel> Directions { get; set; }
    }
}
