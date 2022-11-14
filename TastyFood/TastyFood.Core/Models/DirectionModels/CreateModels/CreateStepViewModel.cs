namespace TastyFood.Core.Models.DirectionModels.CreateModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateStepViewModel
    {
        [Required]
        public string Information { get; set; } = null!;
    }
}