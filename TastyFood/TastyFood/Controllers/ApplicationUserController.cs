namespace TastyFood.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using TastyFood.Contracts;
    using TastyFood.Core.Models.ApplicationUserModels.LoginModels;
    using TastyFood.Core.Models.ApplicationUserModels.RegisterModels;

    [Authorize]
    public class ApplicationUserController : Controller
    {
        private readonly IApplicationUserService userService;

        public ApplicationUserController(IApplicationUserService userService)
        {
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            var model = this.userService.CreateRegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            var isSucceded = await this.userService.CreateApplicationUserAsync(registerViewModel);

            if (isSucceded)
            {
                // TODO: change it to nameof(this.Login)
                return RedirectToAction("Index", "Home");
            }

            return View(registerViewModel);
        }

        public IActionResult Login()
        {
            var loginViewModel = this.userService.CreateLoginViewModel();

            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var isSignedIn = await this.userService.SignUserInAsync(loginViewModel);

            if (isSignedIn)
            {
                //TODO: Redirect after Login to proper page
                return RedirectToAction("Index", "Home");
            }

            return View(loginViewModel);
        }
    }
}
