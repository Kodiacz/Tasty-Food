﻿namespace TastyFood.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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
        public ApplicationUser User { get; set; } = null!;
    }
}
