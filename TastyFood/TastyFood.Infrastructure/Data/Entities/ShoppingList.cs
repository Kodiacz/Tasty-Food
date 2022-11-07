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
    }
}
