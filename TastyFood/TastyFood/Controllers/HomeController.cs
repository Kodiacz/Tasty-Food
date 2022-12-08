namespace TastyFood.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TastyFood.Core.Contracts;
    using TastyFood.Core.Models.RecipeModels;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}