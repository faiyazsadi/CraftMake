using Microsoft.AspNetCore.Mvc;

namespace CraftMake.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
