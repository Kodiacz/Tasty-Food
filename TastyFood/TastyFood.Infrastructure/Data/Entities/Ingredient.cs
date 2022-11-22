namespace TastyFood.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static TastyFood.Infrastructure.Data.DataConstants.ProductConstants;

    public class Ingredient
    {

        [Key]
        public int Id { get; set; }


        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        [StringLength(QuantityMaxLength, MinimumLength = QuantityMinLength)]
        public string Quantity { get; set; }

        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
