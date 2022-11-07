namespace TastyFood.Infrastructure.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using TastyFood.Infrastructure.Data.Entities;

    public class TastyFoodDbContext : IdentityDbContext
    {
        public TastyFoodDbContext(DbContextOptions<TastyFoodDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Detail> Details { get; set; }

        public DbSet<Direction> Directions { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<NutritionFact> NutritionFacts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<ShoppingList> ShoppingLists { get; set; }

        public DbSet<Step> Steps { get; set; }
    }
}