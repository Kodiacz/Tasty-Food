namespace TastyFood.Core.Models.DirectionModels.CreateModels
{
    using System.ComponentModel.DataAnnotations;

    public class RecipeDirectionStepViewModel
    {
        [Required]
        public string Information { get; set; } = null!;
    }
}