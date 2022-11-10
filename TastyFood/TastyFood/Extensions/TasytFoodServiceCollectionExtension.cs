namespace Microsoft.Extensions.DependencyInjection
{
    using TastyFood.Contracts;
    using TastyFood.Services;

    public static class TastyFoodServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationUserService, ApplicationUserService>();

            return services;
        }
    }
}
