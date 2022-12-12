namespace TastyFood.Core.Models.DirectionModels
{
    using System.ComponentModel.DataAnnotations;

    using static TastyFood.Infrastructure.Data.DataConstants.DirectionConstants;

    public class DirectionViewModel
    {
        [Required]
        [StringLength(StepMaxLength, ErrorMessage = "The step must be less then 450 symbols")]
        public string Step { get; set; } = null!;
    }
}