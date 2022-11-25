using HouseRentingSystem.Extensions;
using Microsoft.AspNetCore.Mvc;
using TastyFood.Core.Contracts;
using TastyFood.Core.Models.RecipeModels;

namespace TastyFood.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeService recipeService;
        private readonly string currentUserId;
        private readonly string currentUserName;

        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
            this.currentUserId = User.Id();
            this.currentUserName = User.Identity.Name;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = this.recipeService.CreateRecipeViewModel();

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeViewModel model)
        {
            await this.recipeService.CreateRecipe(model, this.currentUserId);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> MyRecipes()
        {
            var model = await this.recipeService.GetAllUserOwnRecipes(this.currentUserId, this.currentUserName);

            return View(model);
        }
    }
}
