namespace TastyFood.Controllers
{
    using TastyFood.Extensions;
    using TastyFood.Core.Contracts;
    using TastyFood.Core.Models.RecipeModels;
    using TastyFood.Infrastructure.Data.DataConstants;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using TastyFood.Exceptions;

    [Authorize]
    public class RecipeController : Controller
    {
        private readonly IRecipeService recipeService;

        private readonly IShoppingListService shoppingListService;

        public RecipeController(IRecipeService recipeService, IShoppingListService shoppingListService)
        {
            this.recipeService = recipeService;
            this.shoppingListService = shoppingListService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Create()
        {
            var model = this.recipeService.CreateRecipeViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
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

        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> MyRecipes()
        {
            var currentUserId = User.Id();

            var model = await this.recipeService.GetAllUserOwnRecipesAsync(currentUserId);

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Detail(int id)
        {
            string currentUserName = User?.Identity?.Name;
            string currentUserId = User.Id();

            try
            {
                var model = await this.recipeService.GetRecipeWithIdAsync(id, currentUserName);
                model.ShoppingListId = this.shoppingListService.GetCurrentUserShoppingListId(currentUserId, id);

                return View(model);
            }
            catch (AlreadyDeletedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.recipeService.CreateEditRecipeViewModelAsync(id);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Edit(EditRecipeViewModel model, int id)
        {
            await this.recipeService.UpdateRecipeAsync(model, id);

            return RedirectToAction(nameof(Detail), new { id = id });
        }

        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.recipeService.DeleteSoftAsync(id);

            return RedirectToAction(nameof(MyRecipes));
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllRecipes()
        {
            ViewBag.NoRecipesMessage = "There are no created recepie to show yet";

            IEnumerable<AllRecipeViewModel> model = await this.recipeService.GetAllRecipesAsync();

            AllRecipesViewModelContainer modelContainer = new()
            {
                RecipeModels = model,
            };

            return View(modelContainer);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllRecipesFiltered(AllRecipesViewModelContainer modelContainer)
        {
            ViewBag.NoRecipesMessage = "There are no recepies matching your search";

            modelContainer.RecipeModels = await this.recipeService.GetSearchedRecipesAsync(modelContainer.FilterForRecipes.SearchBy!, modelContainer.FilterForRecipes.Filter!); 

            return View("AllRecipes", modelContainer);
        }

        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> AddToFavorites(int id)
        {
            string currentUserId = this.User.Id();

            if (!this.User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Register", "ApplicationUser");
            }

            await this.recipeService.AddRecipeToUserFavoritesListAsync(id, currentUserId);

            return RedirectToAction(nameof(AllRecipes));
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            string curretnUserId = this.User.Id();

            var model = await this.recipeService.GetUserFavoriteRecipes(curretnUserId);

            return View(model);
        }

        public async Task<IActionResult> RemoveFromFavorites(int id)
        {
            string currentUserId = this.User.Id();

            await this.recipeService.RemoveFromFavorites(id, currentUserId);

            return RedirectToAction(nameof(Favorites));
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> SearchForRecipe(string searchBy, string input)
        //{
        //    var model = await this.recipeService.GetSearchedRecipesAsync(searchBy, input);

        //    TempData["FilteredRecipes"] = model;
        //    return Json(new { redirectToUrl = Url.Action("AllRecipesFiltered", "Recipe") });
        //    //return RedirectToAction(nameof(AllRecipesFiltered));
        //}
    }
}
