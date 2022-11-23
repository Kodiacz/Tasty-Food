namespace TastyFood.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static TastyFood.Infrastructure.Data.DataConstants.ProductConstants;

    [NotMapped]
    public class Product
    {
        public Product()
        {
            this.ShoppingLists = new HashSet<ShoppingList>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; }

        //[Required]
        //[ForeignKey(nameof(Category))]
        //public int CategoryId { get; set; }
        //public Category Category { get; set; } = null!;


        [Required]
        [ForeignKey(nameof(Ingredient))]
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = null!;

        public virtual ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}
