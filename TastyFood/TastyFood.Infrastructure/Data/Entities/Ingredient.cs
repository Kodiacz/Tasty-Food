namespace TastyFood.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class Ingredient
    {
        public Ingredient()
        {
            this.Products = new List<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public IEnumerable<Product> Products { get; set; }
    }
}
