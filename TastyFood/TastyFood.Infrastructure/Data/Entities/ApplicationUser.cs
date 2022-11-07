namespace TastyFood.Infrastructure.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [ForeignKey(nameof(ShoppingList))]
        public int ShoppingListId { get; set; }
        public ShoppingList? ShoppingList { get; set; }

        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
    }
}
