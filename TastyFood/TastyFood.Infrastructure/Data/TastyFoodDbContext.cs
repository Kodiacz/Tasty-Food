namespace TastyFood.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using TastyFood.Infrastructure.Data.Entities;

    public class TastyFoodDbContext : IdentityDbContext<ApplicationUser>
    {
        public TastyFoodDbContext(DbContextOptions<TastyFoodDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //builder.Entity<ApplicationUser>()
            //    .HasMany(au => au.FavoriteRecipes)
            //    .WithMany(fr => fr.UsersFavoriteRecipes);

            builder.Entity<Ingredient>()
                .HasOne(i => i.ShoppingList)
                .WithMany(i => i.Ingredients)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }


        //TODO: Move before the methods
        public DbSet<Direction> Directions { get; set; } = null!;

        public DbSet<Ingredient> Ingredients { get; set; } = null!;

        public DbSet<Recipe> Recipes { get; set; } = null!;

        public DbSet<ShoppingList> ShoppingLists { get; set; } = null!;
    }
}