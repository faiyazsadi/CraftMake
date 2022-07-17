using Microsoft.AspNetCore.Mvc;

namespace CraftMake.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
