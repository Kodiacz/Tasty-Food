namespace TastyFood.Core.Models.DirectionModels
{
    using System.ComponentModel.DataAnnotations;
    using static TastyFood.Infrastructure.Data.DataConstants.DirectionConstants;

    public class DirectionViewModel
    {
        [Required]
        [StringLength(StepMaxLength)]
        public string Step { get; set; } = null!;
    }
}