namespace TastyFood.Core.Models.ApplicationUserModels.LoginModels
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!
    }
}
