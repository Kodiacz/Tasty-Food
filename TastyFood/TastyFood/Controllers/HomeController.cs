namespace TastyFood.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TastyFood.Core.Contracts;
    using TastyFood.Core.Models.RecipeModels;

    public class HomeController : Controller
    {
        private readonly IRecipeService recipeService;

        public HomeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public async Task<IActionResult> AllRecipes()
        {
            IEnumerable<AllRecipeViewModel> model = await this.recipeService.GetAllRecipesasync();

            return View(model);
        }
    }
}