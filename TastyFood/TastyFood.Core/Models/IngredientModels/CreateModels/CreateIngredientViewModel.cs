namespace TastyFood.Core.Models.IngredientModels.CreateModels
{
    using System.ComponentModel.DataAnnotations;
    using static TastyFood.Infrastructure.Data.DataConstants.ProductConstants;

    public class CreateIngredientViewModel
    {
        [Required]
        [StringLength(NameMaxLength)]
        public string Product { get; set; } = null!;

        [Required]
        [StringLength(QuantityMaxLength, MinimumLength = QuantityMinLength)]
        public string Quantity { get; set; } = null!;
    }
}
