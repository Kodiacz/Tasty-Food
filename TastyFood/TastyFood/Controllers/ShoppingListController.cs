namespace TastyFood.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Net.Http.Headers;
    using System.Text;
    using TastyFood.Core.Models.RecipeModels;

    public class ShoppingListController : Controller
    {
        // TODO: Look for optimisation
        [HttpPost]
        public IActionResult Download(DetailRecipeViewModel model)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var ingredient in model.IngredientsOutput)
            {
                sb.AppendLine(ingredient);
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=ShoppingList.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }
    }
}
