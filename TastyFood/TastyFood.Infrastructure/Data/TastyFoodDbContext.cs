namespace TastyFood.Infrastructure.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using TastyFood.Infrastructure.Data.Entities;

    public class TastyFoodDbContext : IdentityDbContext<ApplicationUser>
    {
        public TastyFoodDbContext(DbContextOptions<TastyFoodDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUserFavoriteRecipe>()
                .HasKey(ar => new { ar.ApplicationUserId, ar.RecipeId });

            builder.Entity<ApplicationUserFavoriteRecipe>()
                .HasOne(ar => ar.User)
                .WithMany(ar => ar.FavoriteRecipes)
                .HasForeignKey(ar => ar.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUserFavoriteRecipe>()
                .HasOne(ar => ar.FavoriteRecipe)
                .WithMany(ar => ar.UsersFavoriteRecipes)
                .HasForeignKey(ar => ar.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Ingredient>()
                .HasOne(i => i.ShoppingList)
                .WithMany(i => i.Ingredients)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }


        public DbSet<Direction> Directions { get; set; } = null!;

        public DbSet<Ingredient> Ingredients { get; set; } = null!;

        public DbSet<Recipe> Recipes { get; set; } = null!;

        public DbSet<ShoppingList> ShoppingLists { get; set; } = null!;
    }
}