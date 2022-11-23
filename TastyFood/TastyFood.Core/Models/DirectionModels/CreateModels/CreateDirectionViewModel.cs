namespace TastyFood.Core.Models.DirectionModels.CreateModels
{
using System.ComponentModel.DataAnnotations;
    using static TastyFood.Infrastructure.Data.DataConstants.DirectionConstants;

    public class CreateDirectionViewModel
    {
        [Required]
        [StringLength(StepMaxLength)]
        public string Step { get; set; } = null!;
    }
}