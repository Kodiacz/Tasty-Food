namespace TastyFood.Services
{
    using Microsoft.AspNetCore.Identity;
    using TastyFood.Contracts;
    using TastyFood.Core.Models.ApplicationUserModels.RegisterModels;
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

        /// <summary>
        /// Creates an ApplicationUser and saves the entity in the database
        /// </summary>
        /// <param name="registerViewModel"></param>
        /// <return>Returns true if the ApplicationUser is created otherwise false</returns>
        public async Task<bool> CreateApplicationUserAsync(RegisterViewModel registerViewModel)
        {
            var user = new ApplicationUser()
            {
                UserName = registerViewModel.Username,
                Email = registerViewModel.Email,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
            };
            
            var result = await userManager.CreateAsync(user, registerViewModel.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);

                return true;
            }

            return false;
        }

    }
}
