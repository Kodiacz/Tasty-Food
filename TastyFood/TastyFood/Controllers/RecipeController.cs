using Microsoft.AspNetCore.Mvc;

namespace TastyFood.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
