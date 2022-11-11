namespace TastyFood.Contracts
{
    using TastyFood.Core.Models.ApplicationUserModels.LoginModels;
    using TastyFood.Core.Models.ApplicationUserModels.RegisterModels;

    public interface IApplicationUserService
    {
        // Register action methods
        public RegisterViewModel CreateRegisterViewModel();
        public Task<bool> CreateApplicationUserAsync(RegisterViewModel registerViewModel);

        // Loging action methods
        public LoginViewModel CreateLoginViewModel();
    }
}
