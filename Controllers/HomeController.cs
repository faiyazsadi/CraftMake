using CraftMake.Context;
using CraftMake.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CraftMake.Controllers
{
    public class HomeController : Controller
    {
        private readonly CraftMakeDatabaseContext _context;

        private readonly ILogger<HomeController> _logger;
        public static List<Product> cart_items = new List<Product>();

        public HomeController(CraftMakeDatabaseContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            HttpContext.Session.SetString("key", "value");
            List<Product> products = new List<Product>();
            products = _context.Product.ToList();

            return View(products);
        }
        
        public IActionResult Details(int id)
        {
            return View(_context.Product.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public ViewResult GetUserInfo(User userInfo)
        {
            return (View("UserInfo", userInfo));
        }

        public IActionResult SignOut()
        {
            ApplicationGlobal.LoggedIn = false;
            ApplicationGlobal.userName = "";
            return View("Index");
        }

        public IActionResult Privacy()
        {
            ViewBag.SessionValue = HttpContext.Session.GetString("key");
            return View();
        }

        public IActionResult Cart()
        {
            return View(cart_items);
        }

        [HttpPost]
        public IActionResult Cart(Product model)
        {
            int id = model.Id;
            cart_items.Add(_context.Product.FirstOrDefault(x => x.Id == id));
            return View(cart_items);
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}