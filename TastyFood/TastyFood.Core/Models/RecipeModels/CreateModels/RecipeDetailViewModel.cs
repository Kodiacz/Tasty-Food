using System.ComponentModel.DataAnnotations;

namespace TastyFood.Core.Models.RecipeModels.CreateModels
{
    public class RecipeDetailViewModel
    {
        [Required]
        public int PreparationTime { get; set; }

        [Required]
        public int CookTime { get; set; }

        [Required]
        public int AdditionalTime { get; set; }

        [Required]
        public int ServingsQuantity { get; set; }
    }
}