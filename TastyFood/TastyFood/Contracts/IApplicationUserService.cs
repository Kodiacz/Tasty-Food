namespace TastyFood.Contracts
{
    using TastyFood.Core.Models.ApplicationUserModels.RegisterModels;

    public interface IApplicationUserService
    {
        public Task<bool> CreateApplicationUserAsync(RegisterViewModel registerViewModel);
    }
}
