using System.ComponentModel.DataAnnotations;
using TastyFood.Core.Models.DetailModels.CreateModels;

namespace TastyFood.Core.Models.RecipeModels.CreateModels
{
    public class RecipeCreateViewModel
    {
        public RecipeCreateViewModel()
        {
            this.Ingredients = new List<RecipeIngredientsViewModel>();
            this.Directions = new List<RecipeDirectionViewModel>();
            this.NutritionFacts = new List<RecipeNutritionFactModel>();
        }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string CreatorUsername { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string Image { get; set; } = null!;

        public RecipeDetailViewModel Details { get; set; }

        public IEnumerable<RecipeIngredientsViewModel> Ingredients { get; set; }

        public IEnumerable<RecipeDirectionViewModel> Directions { get; set; }

        public IEnumerable<RecipeNutritionFactModel> NutritionFacts { get; set; }
    }
}
