namespace TastyFood.HelperMethods
{
    using Microsoft.AspNetCore.Identity;

    public static class AddDefaultIdentityOptions
    {
        /// <summary>
        /// Adding confuguration options to IdentityOptions 
        /// for PasswordOptions and SignInOptions
        /// </summary>
        /// <param name="options">parameter of  type options</param>
        public static void AddOptions(IdentityOptions options)
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
        }
    }
}
