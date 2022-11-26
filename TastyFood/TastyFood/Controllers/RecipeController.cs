using HouseRentingSystem.Extensions;
using Microsoft.AspNetCore.Mvc;
using TastyFood.Core.Contracts;
using TastyFood.Core.Models.RecipeModels;

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
            var model = this.recipeService.CreateRecipeViewModel();

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeViewModel model)
        {
            var currentUserId = User.Id();
            
            await this.recipeService.CreateRecipeAsync(model, currentUserId);

            return RedirectToAction(nameof(MyRecipes));
        }

        public async Task<IActionResult> MyRecipes()
        {
            var currentUserId = User.Id();

            var model = await this.recipeService.GetAllUserOwnRecipesAsync(currentUserId);

            return View(model);
        }


        public async Task<IActionResult> Detail(int id)
        {
            var currentUserName = User?.Identity?.Name;
            var model = await this.recipeService.GetRecipeWithIdAsync(id, currentUserName);

            return View(model);
        }
    }
}
