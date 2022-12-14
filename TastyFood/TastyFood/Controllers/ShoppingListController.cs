namespace TastyFood.Controllers
{
    using System.Text;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Net.Http.Headers;
    using TastyFood.Core.Contracts;
    using TastyFood.Core.Models.RecipeModels;
    using TastyFood.Core.Models.ShoppingListModels;
    using TastyFood.Extensions;
    using TastyFood.Infrastructure.Data.Entities;

    public class ShoppingListController : Controller
    {
        private readonly IShoppingListService shoppingListService;

        public ShoppingListController(IShoppingListService shoppingListService)
        {
            this.shoppingListService = shoppingListService;
        }

        // TODO: Look for optimisation
        [HttpPost]
        public IActionResult Download(DetailRecipeViewModel model, int id)
        {
            if (model == null || model.IngredientsOutput.Count == 0)
            {
                return RedirectToAction("Detail", "Recipe", new { id = id });
            }

            StringBuilder sb = new StringBuilder();

            foreach (var ingredient in model.IngredientsOutput)
            {
                sb.AppendLine(ingredient);
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=ShoppingList.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }

        [HttpPost]
        public async Task<IActionResult> Save(DetailRecipeViewModel recipeModel, int id)
        {
            string currentUserId = User.Id();
            string currentUsername = User?.Identity?.Name!;

            CreateShoppingListViewModel shoppingListModel = this.shoppingListService.CreateShoppingListViewModel(recipeModel, currentUserId, currentUsername);
            await this.shoppingListService.CreateShoppintListAsync(shoppingListModel, id);

            recipeModel.Creator = this.shoppingListService.GetOwnerOfRecipe(id);
            recipeModel.ShoppingListId = this.shoppingListService.GetCurrentUserShoppingListId(currentUserId, id);

            return View("~/Views/Recipe/Detail.cshtml", recipeModel);
        }
    }
}
