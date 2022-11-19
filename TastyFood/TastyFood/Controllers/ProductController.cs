namespace TastyFood.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ProductController : Controller
    {
        [HttpGet]
       public IActionResult Create()
        {
            return View();
        }
    }
}
