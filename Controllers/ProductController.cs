using CraftMake.Context;
using CraftMake.Models;
using Microsoft.AspNetCore.Mvc;

namespace CraftMake.Controllers
{
    public class ProductController : Controller
    {
        private readonly CraftMakeDatabaseContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public static List<Product> awaiting_approval = new List<Product>();
        public ProductController(CraftMakeDatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
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
                return View("Index");
            }
            
            return View("../Home/Index");
        }
    }
}
