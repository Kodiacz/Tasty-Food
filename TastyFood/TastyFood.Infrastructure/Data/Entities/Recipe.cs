namespace TastyFood.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static TastyFood.Infrastructure.Data.DataConstants.RecipeConstants;

    public class Recipe
    {
        public Recipe()
        {
            this.Ingredients = new HashSet<Ingredient>();
            this.Directions = new HashSet<Direction>();
            this.UsersFavoriteRecipes = new HashSet<ApplicationUserFavoriteRecipe>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        [Required]
        public int PreparationTime { get; set; }

        [Required]
        public int CookTime { get; set; }

        [Required]
        public int AdditionalTime { get; set; }

        [Required]
        public int ServingsQuantity { get; set; }

        [InverseProperty(nameof(Ingredient.Recipe))]
        public ICollection<Ingredient> Ingredients { get; set; } 

        [InverseProperty(nameof(Ingredient.Recipe))]
        public ICollection<Direction> Directions { get; set; }

        [ForeignKey(nameof(UserOwner))]
        [Required]
        public string UserOwnerId { get; set; } = null!;
        [InverseProperty(nameof(ApplicationUser.OwnRecipes))]
        public ApplicationUser UserOwner { get; set; } = null!;

        public virtual ICollection<ApplicationUserFavoriteRecipe> UsersFavoriteRecipes { get; set; }
    }
}