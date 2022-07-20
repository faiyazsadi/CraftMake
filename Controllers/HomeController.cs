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
        public static List<Product> products = new List<Product>();
        public static List<Product> cart_items = new List<Product>();

        public HomeController(CraftMakeDatabaseContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            products = _context.Product.Take(8).ToList();

            return View(products);
        }
        
        public IActionResult Details(int id)
        {
            if(HttpContext.Session.GetString("SignedIn") == null || HttpContext.Session.GetString("SignedIn") == "")
            {
                HttpContext.Session.SetInt32("id", id);
            }
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
            if (HttpContext.Session.GetString("SignedIn") == null || HttpContext.Session.GetString("SignedIn") == "")
            {
                return RedirectToAction("Index", "SignIn");
            }
            return View(cart_items);
        }

        public IActionResult RemoveItem(int id)
        {
            foreach(var item in cart_items)
            {
                if(item.Id == id)
                {
                    cart_items.Remove(item);
                    break;
                }
            }
            return RedirectToAction("Cart");
        }
        [HttpPost]
        public IActionResult Cart(Product model)
        {
            if (HttpContext.Session.GetString("SignedIn") == null || HttpContext.Session.GetString("SignedIn") == "")
            {
                return RedirectToAction("Index", "SignIn");
            }
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