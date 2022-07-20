using CraftMake.Context;
using CraftMake.Models;
using Microsoft.AspNetCore.Mvc;

namespace CraftMake.Controllers
{
    public class ProductController : Controller
    {
        private readonly CraftMakeDatabaseContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public static List<Product> new_products = new List<Product>();
        public static List<Product> awaiting_approval = new List<Product>();
        public ProductController(CraftMakeDatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("sellPage", 1);
            if (HttpContext.Session.GetString("SignedIn") == null || HttpContext.Session.GetString("SignedIn") == "")
            {
                return RedirectToAction("Index", "SignIn");
            }
            return View();
        }
        public IActionResult NewProducts()
        {
            new_products = _context.Product.OrderByDescending(x => x.Id).Take(5).ToList();
            return View(new_products);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if(product.CoverPhoto != null)
            {
                string folder = "img/product-img/";
                folder += Guid.NewGuid().ToString() + "_" + product.CoverPhoto.FileName;
                product.ImagePath = "/" + folder;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                await product.CoverPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

                var newProduct = new Product()
                {
                    ProductName = product.ProductName,
                    ProductQuantity = product.ProductQuantity,
                    IsApproved = 0,
                    ProductPrice = product.ProductPrice,
                    userEmail = product.userEmail,
                    ProductDescription = product.ProductDescription,
                    ImagePath = product.ImagePath
                };
                await _context.Product.AddAsync(newProduct);
                await _context.SaveChangesAsync();
                awaiting_approval.Add(newProduct);
                HttpContext.Session.SetInt32("itemPosted", 1);
                return View("Index");
            }
            
            return View("../Home/Index");
        }
        public string Search(string query)
        {
            return query;
        }
        public IActionResult OrderPlaced()
        {
            HttpContext.Session.SetInt32("OrderPlaced", 1);
            return View("../Home/Checkout");
        }
    }
}
