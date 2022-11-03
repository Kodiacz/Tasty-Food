namespace TastyFood.Infrastructure.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class TastyFoodDbContext : IdentityDbContext
    {
        public TastyFoodDbContext(DbContextOptions<TastyFoodDbContext> options)
            : base(options)
        {
        }
    }
}