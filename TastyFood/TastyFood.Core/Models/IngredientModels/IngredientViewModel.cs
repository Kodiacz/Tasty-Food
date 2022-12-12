namespace TastyFood.Core.Models.IngredientModels
{
    using System.ComponentModel.DataAnnotations;

    using static TastyFood.Infrastructure.Data.DataConstants.IngredientConstants;

    public class IngredientViewModel
    {
        [Required]
        [StringLength(ProductMaxLength, MinimumLength = ProductNameMinLength, ErrorMessage = "Product must be less then 70 symbols")]
        public string Product { get; set; } = null!;

        [Required]
        [StringLength(QuantityMaxLength, MinimumLength = QuantityMinLength, ErrorMessage = "Quantity must be less then 70 symbols")]
        public string Quantity { get; set; } = null!;
    }
}
