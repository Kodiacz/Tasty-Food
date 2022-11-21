namespace TastyFood.Core.Models.IngredientModels.CreateModels
{
    using System.ComponentModel.DataAnnotations;
    using static TastyFood.Infrastructure.Data.DataConstants.ProductConstants;

    public class CreateIngredientViewModel
    {
        public CreateProductViewModel Product { get; set; }


        [Required]
        [StringLength(QuantityMaxLength, MinimumLength = QuantityMinLength)]
        public string Quantity { get; set; }
    }
}