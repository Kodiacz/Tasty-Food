namespace TastyFood.Core.Models.DetailModels.CreateModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateDetailViewModel
    {
        [Required]
        [Range(1, 300)]
        public int PreparationTime { get; set; }

        [Required]
        [Range(1, 300)]
        public int CookTime { get; set; }

        [Required]
        [Range(1, 300)]
        public int AdditionalTime { get; set; }

        [Required]
        [Range(1, 300)]
        public int ServingsQuantity { get; set; }
    }
}