namespace TastyFood.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TastyFood.Core.Models.ApplicationUserModels.RegisterModels;
    using TastyFood.Infrastructure.Data.Entities;

    [Authorize]
    public class ApplicationUserController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Regiser(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }


        }
    }
}
