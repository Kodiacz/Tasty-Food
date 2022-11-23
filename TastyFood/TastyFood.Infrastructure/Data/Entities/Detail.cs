namespace TastyFood.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [NotMapped]
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
