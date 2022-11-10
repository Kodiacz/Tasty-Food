namespace TastyFood.Services
{
    using Microsoft.AspNetCore.Identity;
    using TastyFood.Contracts;
    using TastyFood.Infrastructure.Data.Entities;

    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public ApplicationUserService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


    }
}
