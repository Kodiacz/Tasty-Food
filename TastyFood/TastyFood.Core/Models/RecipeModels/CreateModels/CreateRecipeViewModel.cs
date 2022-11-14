using System.ComponentModel.DataAnnotations;
using TastyFood.Core.Models.DetailModels.CreateModels;
using TastyFood.Core.Models.DirectionModels.CreateModels;
using TastyFood.Core.Models.IngredientModels.CreateModels;
using TastyFood.Core.Models.NutritionFactModels.CreateModels;

namespace TastyFood.Core.Models.RecipeModels.CreateModels
{
    public class CreateRecipeViewModel
    {
        public CreateRecipeViewModel()
        {
            this.Ingredients = new List<CreateIngredientViewModel>();
            this.Directions = new List<CreateDirectionViewModel>();
            this.NutritionFacts = new List<CreateNutritionFactViewModel>();
        }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string CreatorUsername { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string Image { get; set; } = null!;

        public CreateDetailViewModel Details { get; set; }

        public IEnumerable<CreateIngredientViewModel> Ingredients { get; set; }

        public IEnumerable<CreateDirectionViewModel> Directions { get; set; }

        public IEnumerable<CreateNutritionFactViewModel> NutritionFacts { get; set; }
    }
}
