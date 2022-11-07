namespace TastyFood.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static TastyFood.Infrastructure.Data.DataConstants.ProductConstants;

    public class Product
    {
        public Product()
        {
            this.NutritionFacts = new List<NutritionFact>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        [Required]
        [StringLength(QuantityMaxLength, MinimumLength = QuantityMinLength)]
        public string Quantity { get; set; }

        public IEnumerable<NutritionFact> NutritionFacts { get; set; }
    }
}
