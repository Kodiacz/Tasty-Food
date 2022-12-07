namespace TastyFood.Core.Models.IngredientModels
{
    using System.ComponentModel.DataAnnotations;

    using static TastyFood.Infrastructure.Data.DataConstants.IngredientConstants;

    public class IngredientViewModel
    {
        [Required]
        [StringLength(ProductMaxLength)]
        public string Product { get; set; } = null!;

        [Required]
        [StringLength(QuantityMaxLength, MinimumLength = QuantityMinLength)]
        public string Quantity { get; set; } = null!;
    }
}
