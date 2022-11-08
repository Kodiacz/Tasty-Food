namespace TastyFood.Infrastructure.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.ShoppingLists = new List<ShoppingList>();
            this.OwnRecipes = new List<Recipe>();
            this.FavoriteRecipes = new List<Recipe>();
        }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        public IEnumerable<ShoppingList> ShoppingLists { get; set; }

        public IEnumerable<Recipe> OwnRecipes { get; set; }

        public IEnumerable<Recipe> FavoriteRecipes { get; set; }
    }
}
