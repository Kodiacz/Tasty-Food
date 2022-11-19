namespace Microsoft.Extensions.DependencyInjection
{
    using TastyFood.Contracts;
    using TastyFood.Core.Contracts;
    using TastyFood.Core.Services;
    using TastyFood.Infrastructure.Data.Common;
    using TastyFood.Services;

    public static class TastyFoodServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IRepository, Repository>();


            return services;
        }
    }
}
