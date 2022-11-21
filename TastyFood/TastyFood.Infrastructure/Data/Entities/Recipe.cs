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

        public bool IsDeleted { get; set; } = false;

        [Required]
        public ICollection<Ingredient> Ingredients { get; set; } 

        public IEnumerable<Direction> Directions { get; set; } 


        [ForeignKey(nameof(Details))]
        public int DetailsId { get; set; }
        public Detail? Details { get; set; }

        [ForeignKey(nameof(UserOwner))]
        public string UserOwnerId { get; set; }
        public ApplicationUser UserOwner { get; set; }

        public IEnumerable<ApplicationUser> UsersFavoriteRecipes { get; set; }
    }
}