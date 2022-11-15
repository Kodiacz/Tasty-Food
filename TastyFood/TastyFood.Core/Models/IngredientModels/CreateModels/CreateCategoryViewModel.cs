namespace TastyFood.Core.Models.IngredientModels.CreateModels
{
    using System.ComponentModel.DataAnnotations;
    using static TastyFood.Infrastructure.Data.DataConstants.CategoryConstants;
    public class CreateCategoryViewModel
    {
        [Required]
        [StringLength(TypeMaxLength, MinimumLength = TypeMinLength)]
        public string Type { get; set; }
    }
}