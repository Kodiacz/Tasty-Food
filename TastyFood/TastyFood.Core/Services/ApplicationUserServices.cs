namespace TastyFood.Services
{
    using Microsoft.AspNetCore.Identity;
    using TastyFood.Contracts;
    using TastyFood.Core.Models.ApplicationUserModels.LoginModels;
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

        /// <summary>
        /// creating a LoginVideModel and returns it
        /// </summary>
        /// <returns>
        /// LoginViewModel
        /// </returns>
        public LoginViewModel CreateLoginViewModel() => new LoginViewModel();
        
        /// <summary>
        /// created a RegisterViewModel and returns it
        /// </summary>
        /// <returns>
        /// RegisterViewModel
        /// </returns>
        public RegisterViewModel CreateRegisterViewModel() => new RegisterViewModel();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
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
