namespace TastyFood.Core.Models.IngredientModels.CreateModels
{
    using System.ComponentModel.DataAnnotations;
    using static TastyFood.Infrastructure.Data.DataConstants.ProductConstants;

    public class CreateProductViewModel
    {
        public CreateCategoryViewModel Category { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; }
    }
}