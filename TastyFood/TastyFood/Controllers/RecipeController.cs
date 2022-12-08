namespace TastyFood.Controllers
{
    using TastyFood.Extensions;
    using TastyFood.Core.Contracts;
    using TastyFood.Core.Models.RecipeModels;
    using TastyFood.Infrastructure.Data.DataConstants;

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
            int[] indexes = new[] { 0, 0, 0 };

            foreach (var item in ModelState)
            {
                if (item.Key.Contains($"Ingredients[{indexes[0]}].Product"))
                {
                    if (item.Value.Errors.Count > 0)
                    {
                        ViewData[$"{ErrorConstants.ProductMessage}{indexes[0]}"] = "Product should be less then 70 charrackters long";
                    }

                    indexes[0]++;
                }

                if (item.Key.Contains($"Ingredients[{indexes[1]}].Quantity"))
                {
                    if (item.Value.Errors.Count > 0)
                    {
                        ViewData[$"{ErrorConstants.QuantityMessage}{indexes[1]}"] = "Quantity should be less then 70 charrackters long";
                    }

                    indexes[1]++;
                }

                if (item.Key.Contains($"Directions[{indexes[2]}].Step"))
                {
                    if (item.Value.Errors.Count > 0)
                    {
                        ViewData[$"{ErrorConstants.StepMessage}{indexes[2]}"] = "Step should be less then 450 charrackters long";
                    }

                    indexes[2]++;
                }
            }

            if (!ModelState.IsValid)
            {
                return View("RepeatCreate", model);
            }

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

        [AllowAnonymous]
        public async Task<IActionResult> Detail(int id)
        {
            var currentUserName = User?.Identity?.Name;
            try
            {
                var model = await this.recipeService.GetRecipeWithIdAsync(id, currentUserName);
                return View(model);
            }
            catch (Exception)
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
