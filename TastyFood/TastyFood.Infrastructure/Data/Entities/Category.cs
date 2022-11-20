namespace TastyFood.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using static TastyFood.Infrastructure.Data.DataConstants.CategoryConstants;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(TypeMaxLength, MinimumLength = TypeMinLength)]
        public string Type { get; set; } = null!;

        public IEnumerable<Product> Products { get; set; }
    }
}
