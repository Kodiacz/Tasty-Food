namespace TastyFood.Contracts
{
    using TastyFood.Core.Models.ApplicationUserModels.LoginModels;
    using TastyFood.Core.Models.ApplicationUserModels.RegisterModels;

    public interface IApplicationUserService
    {
        // Register action methods
        /// <summary>
        /// Creating a RegisterViewModel and returns it
        /// </summary>
        /// <returns>
        /// RegisterViewModel
        /// </returns>
        public RegisterViewModel CreateRegisterViewModel();
        /// <summary>
        /// Adding ApplicationUser entity in the database
        /// </summary>
        /// <param name="registerViewModel">RegisterViewModel passed from the View method</param>
        /// <returns></returns>
        public Task<bool> CreateApplicationUserAsync(RegisterViewModel registerViewModel);

        // Login action methods
        /// <summary>
        /// Creating a LoginVideModel and returns it
        /// </summary>
        /// <returns>
        /// LoginViewModel
        /// </returns>
        public LoginViewModel CreateLoginViewModel();
        /// <summary>
        /// Signing the user in the system
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        public Task<bool> SignApplicationUserInAsync(LoginViewModel loginViewModel);

        // Logout action methods
        /// <summary>
        /// Signing out the ApplicationUser
        /// </summary>
        /// <returns></returns>
        public Task SignOutApplicationUserAsync();
    }
}
