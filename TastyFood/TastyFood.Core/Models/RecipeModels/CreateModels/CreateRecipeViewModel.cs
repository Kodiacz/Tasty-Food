using System.ComponentModel.DataAnnotations;
using TastyFood.Core.Models.DetailModels.CreateModels;
using TastyFood.Core.Models.DirectionModels.CreateModels;
using TastyFood.Core.Models.IngredientModels.CreateModels;

namespace TastyFood.Core.Models.RecipeModels.CreateModels
{
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

        public CreateDetailViewModel Details { get; set; }

        public IEnumerable<CreateIngredientViewModel> Ingredients { get; set; }

        public IEnumerable<CreateDirectionViewModel> Directions { get; set; }
    }
}
