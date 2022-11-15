namespace TastyFood.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using static TastyFood.Infrastructure.Data.DataConstants.DirectionConstants;

    public class Direction
    {
        public int Id { get; set; }

        [Required]
        [StringLength(StepMaxLength)]
        public string Step { get; set; }
    }
}
