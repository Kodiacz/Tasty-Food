using System.ComponentModel.DataAnnotations;
using static TastyFood.Infrastructure.Data.DataConstants.NutritionFactConstants;

namespace TastyFood.Core.Models.NutritionFactModels.CreateModels
{
    public class CreateNutritionFactViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        [Required]
        public int Value { get; set; }
    }
}