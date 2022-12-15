namespace TastyFood.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static TastyFood.Infrastructure.Data.DataConstants.ShoppingListConstants;

    public class ShoppingList
    {
        public ShoppingList()
        {
            this.Ingredients = new HashSet<Ingredient>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        [InverseProperty(nameof(ApplicationUser.ShoppingLists))]
        public ApplicationUser User { get; set; } = null!;

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
