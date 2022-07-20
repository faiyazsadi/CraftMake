using CraftMake.Context;
using CraftMake.Models;
using Microsoft.AspNetCore.Mvc;

namespace CraftMake.Controllers
{
    public class AdminController : Controller
    {
        private readonly CraftMakeDatabaseContext _context;

        public AdminController(CraftMakeDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(ProductController.awaiting_approval);
        }
        public IActionResult AddItem(int id)
        {
            _context.Product.FirstOrDefault(x => x.Id == id).IsApproved = 1;
            var removeProduct = _context.Product.FirstOrDefault(x => x.Id == id);
            foreach(var product in ProductController.awaiting_approval)
            {
                if(product.Id == id)
                {
                    removeProduct = product;
                    
                }
            }
            _context.SaveChanges();
            var new_product = _context.Product.FirstOrDefault(x => x.Id == id);
            ProductController.new_products.Add(new_product);
            ProductController.awaiting_approval.Remove(removeProduct);
            return View("Index", ProductController.awaiting_approval);
        }
        public IActionResult RemoveItem(int id)
        {
            _context.Product.FirstOrDefault(x => x.Id == id).IsApproved = 0;
            var removeProduct = _context.Product.FirstOrDefault(x => x.Id == id);
            foreach (var product in ProductController.awaiting_approval)
            {
                if (product.Id == id)
                {
                    removeProduct = product;
                }
            }
            _context.SaveChanges();
            ProductController.awaiting_approval.Remove(removeProduct);
            return View("Index", ProductController.awaiting_approval);
        }
    }
}
