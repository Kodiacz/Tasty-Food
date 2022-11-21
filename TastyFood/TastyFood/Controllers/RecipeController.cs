using HouseRentingSystem.Extensions;
using Microsoft.AspNetCore.Mvc;
using TastyFood.Core.Contracts;
using TastyFood.Core.Models.RecipeModels.CreateModels;

namespace TastyFood.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeService recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var currentUserId = User.Id();
            var model = this.recipeService.CreateRecipeViewModel();
            model.CreatorUsername = User.Identity.Name;

            return View(model);

        }

        public IActionResult Create(CreateRecipeViewModel model)
        {
            return this.Json(model);

            //return RedirectToAction("Create", "Product", recipeViewModel);
        }
    }
}
