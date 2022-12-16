namespace TastyFood.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static TastyFood.Infrastructure.Data.DataConstants.IngredientConstants;

    public class Ingredient
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ProductMaxLength, MinimumLength = ProductNameMinLength)]
        public string Product { get; set; } = null!;

        [Required]
        [StringLength(QuantityMaxLength, MinimumLength = QuantityMinLength)]
        public string Quantity { get; set; } = null!;

        [ForeignKey(nameof(Recipe))]
        public int? RecipeId { get; set; }
        public Recipe? Recipe { get; set; }

        [ForeignKey(nameof(ShoppingList))]
        public int? ShoppingListId { get; set; }
        public ShoppingList? ShoppingList { get; set; }
    }
}
