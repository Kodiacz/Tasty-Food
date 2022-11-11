namespace TastyFood.Contracts
{
    using TastyFood.Core.Models.ApplicationUserModels.RegisterModels;

    public interface IApplicationUserService
    {
        // Register action methods
        public RegisterViewModel CreateRegisterViewModel() => new RegisterViewModel();
        public Task<bool> CreateApplicationUserAsync(RegisterViewModel registerViewModel);

        // Loging action methods
        public LoginViewModel CreateLoginViewModel() => new LoginViewModel();
    }
}
