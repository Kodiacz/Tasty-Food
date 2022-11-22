namespace TastyFood.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static TastyFood.Infrastructure.Data.DataConstants.CategoryConstants;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(TypeMaxLength, MinimumLength = TypeMinLength)]
        public string Type { get; set; } = null!;

        [ForeignKey(nameof(Product))]
        public int ProducId { get; set; }
        public Product Product { get; set; }
    }
}
