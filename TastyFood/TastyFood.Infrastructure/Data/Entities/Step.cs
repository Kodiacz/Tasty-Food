using System.ComponentModel.DataAnnotations;

namespace TastyFood.Infrastructure.Data.Entities
{
    public class Step
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Information { get; set; } = null!;
    }
}
