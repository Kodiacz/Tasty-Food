namespace TastyFood.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static TastyFood.Infrastructure.Data.DataConstants.DirectionConstants;

    public class Direction
    {
        public int Id { get; set; }

        [Required]
        [StringLength(StepMaxLength)]
        public string Step { get; set; } = null!;

        [ForeignKey(nameof(Recipe))]
        [Required]
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;
    }
}
