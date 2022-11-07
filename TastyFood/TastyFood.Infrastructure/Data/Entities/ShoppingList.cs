using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TastyFood.Infrastructure.Data.Entities
{
    public class ShoppingList
    {
        public ShoppingList()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; set; }

        public IEnumerable<Product> Products { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
