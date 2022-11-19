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
            builder.Entity<ApplicationUser>()
                .HasMany(au => au.OwnRecipes)
                .WithOne(or => or.UserOwner)
                .HasForeignKey(or => or.UserOwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(au => au.FavoriteRecipes)
                .WithMany(fr => fr.UsersFavoriteRecipes);

            //builder.Entity<UserRecipe>()
            //    .HasKey(ur => new { ur.UserId, ur.RecipeId });



            base.OnModelCreating(builder);
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Detail> Details { get; set; } = null!;

        public DbSet<Direction> Directions { get; set; } = null!;

        public DbSet<Ingredient> Ingredients { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Recipe> Recipes { get; set; } = null!;

        public DbSet<ShoppingList> ShoppingLists { get; set; } = null!;
    }
}