namespace Microsoft.Extensions.DependencyInjection
{
    using TastyFood.Core;
    using TastyFood.Services;
    using TastyFood.Contracts;
    using TastyFood.Exceptions;
    using TastyFood.Core.Contracts;
    using TastyFood.Core.Services;
    using TastyFood.Infrastructure.Data.Common;

    public static class TastyFoodServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            services.AddScoped<IShoppingListService, ShoppingListService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IGuard, Guard>();

            return services;
        }
    }
}
