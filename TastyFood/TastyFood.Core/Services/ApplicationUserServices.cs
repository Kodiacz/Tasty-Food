namespace TastyFood.Services
{
    using Microsoft.AspNetCore.Identity;

    using TastyFood.Contracts;
    using TastyFood.Infrastructure.Data.Entities;
    using TastyFood.Core.Models.ApplicationUserModels.LoginModels;
    using TastyFood.Core.Models.ApplicationUserModels.RegisterModels;
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
        /// Adding ApplicationUser entity in the database
        /// </summary>
        /// <param name="registerViewModel">RegisterViewModel passed from the View method</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creating a LoginVideModel and returns it
        /// </summary>
        /// <returns>
        /// LoginViewModel
        /// </returns>
        public LoginViewModel CreateLoginViewModel() => new LoginViewModel();
        
        /// <summary>
        /// Created a RegisterViewModel and returns it
        /// </summary>
        /// <returns>
        /// RegisterViewModel
        /// </returns>
        public RegisterViewModel CreateRegisterViewModel() => new RegisterViewModel();

        /// <summary>
        /// Signing the user in the system
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        public async Task<bool> SignApplicationUserInAsync(LoginViewModel loginViewModel)
        {
            var user = await userManager.FindByNameAsync(loginViewModel.Username);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

                if (result.Succeeded)
                {
                    return true;
                }   
            }

            return false;
        }

        /// <summary>
        /// Signing out the ApplicationUser
        /// </summary>
        /// <returns></returns>
        public async Task SignOutApplicationUserAsync()
        {
            await this.signInManager.SignOutAsync();
        }
    }
}
