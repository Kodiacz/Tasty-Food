namespace TastyFood.Controllers
{
    using TastyFood.Extensions;
    using TastyFood.Core.Contracts;
    using TastyFood.Core.Models.RecipeModels;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
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
            try
            {
                var model = await this.recipeService.GetRecipeWithIdAsync(id, currentUserName);
                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.recipeService.CreateEditRecipeViewModelAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditRecipeViewModel model, int id)
        {
            await this.recipeService.UpdateRecipeAsync(model, id);

            return RedirectToAction(nameof(Detail), new { id = id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.recipeService.DeleteSoft(id);

            return RedirectToAction(nameof(MyRecipes));
        }
    }
}
