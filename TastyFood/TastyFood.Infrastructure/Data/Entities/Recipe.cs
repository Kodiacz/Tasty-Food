namespace TastyFood.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static TastyFood.Infrastructure.Data.DataConstants.RecipeConstants;

    public class Recipe
    {
        public Recipe()
        {
            this.Ingredients = new List<Ingredient>();
            this.Directions = new List<Direction>();
            this.NutritionFacts = new List<NutritionFact>();
            this.UsersFavoriteRecipes = new List<ApplicationUser>();
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

        [Required]
        public IEnumerable<Ingredient> Ingredients { get; set; } 

        public IEnumerable<Direction> Directions { get; set; } 

        public IEnumerable<NutritionFact> NutritionFacts { get; set; }

        [ForeignKey(nameof(Details))]
        public int DetailsId { get; set; }
        public Detail? Details { get; set; }

        [ForeignKey(nameof(UserOwner))]
        public string UserOwnerId { get; set; }
        public ApplicationUser UserOwner { get; set; }

        public IEnumerable<ApplicationUser> UsersFavoriteRecipes { get; set; }
    }
}