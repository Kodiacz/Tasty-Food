namespace TastyFood.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static TastyFood.Infrastructure.Data.DataConstants.ProductConstants;

    public class Ingredient
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Product { get; set; } = null!;

        [Required]
        [StringLength(QuantityMaxLength, MinimumLength = QuantityMinLength)]
        public string Quantity { get; set; } = null!;

        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;

        [ForeignKey(nameof(ShoppingList))]
        public int? ShoppingListId { get; set; }
        public ShoppingList? ShoppingList { get; set; }
    }
}
