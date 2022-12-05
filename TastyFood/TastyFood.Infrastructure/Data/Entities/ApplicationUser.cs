namespace TastyFood.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Identity;

    using static TastyFood.Infrastructure.Data.DataConstants.ApplicationUserConstants;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.ShoppingLists = new HashSet<ShoppingList>();
            this.OwnRecipes = new HashSet<Recipe>();
            this.FavoriteRecipes = new HashSet<ApplicationUserFavoriteRecipe>();
        }

        [Required]
        [StringLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<ShoppingList> ShoppingLists { get; set; }

        [InverseProperty(nameof(Recipe.UserOwner))]
        public virtual ICollection<Recipe> OwnRecipes { get; set; }

        public virtual ICollection<ApplicationUserFavoriteRecipe> FavoriteRecipes { get; set; }
    }
}
