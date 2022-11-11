namespace TastyFood.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TastyFood.Contracts;
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
            var model = userService.CreateRegisterViewModel();

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

            var isSucceded = await userService.CreateApplicationUserAsync(registerViewModel);

            if (isSucceded)
            {
                // TODO: change it to nameof(this.Login)
                return RedirectToAction("Login");
            }

            return View(registerViewModel);
        }

        public IActionResult Login()
        {

        }
    }
}
