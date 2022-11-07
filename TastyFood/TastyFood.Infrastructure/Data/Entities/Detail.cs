using System.ComponentModel.DataAnnotations;

namespace TastyFood.Infrastructure.Data.Entities
{
    public class Detail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PreparationTime { get; set; }

        [Required]
        public int CookTime { get; set; }

        [Required]
        public int AdditionalTime { get; set; }

        [Required]
        public int ServingsQuantity { get; set; }
    }
}
