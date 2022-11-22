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
            var model = this.recipeService.CreateRecipeViewModel();

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeViewModel model)
        {
            var currentUserId = User.Id();
            
            await this.recipeService.CreateRecipe(model, currentUserId);

            return RedirectToAction("Index", "Home");
        }
    }
}
