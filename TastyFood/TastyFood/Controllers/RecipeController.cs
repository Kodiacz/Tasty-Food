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
            var recipeViewModel = this.recipeService.CreateRecipeViewModel();

            return View(recipeViewModel);
        }

        public IActionResult Create(CreateRecipeViewModel recipeViewModel)
        {
            return this.Json(recipeViewModel);

            //return RedirectToAction("Create", "Product", recipeViewModel);
        }
    }
}
