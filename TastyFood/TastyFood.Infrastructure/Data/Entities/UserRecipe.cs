namespace TastyFood.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [NotMapped]
    public class UserRecipe
    {
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;
    }
}
