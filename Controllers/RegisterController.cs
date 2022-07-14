using CraftMake.Context;
using CraftMake.Models;
using Microsoft.AspNetCore.Mvc;

namespace CraftMake.Controllers
{
    public class RegisterController : Controller
    {
        private readonly CraftMakeDatabaseContext _context;
        public RegisterController(CraftMakeDatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult AddNewUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            var newUser = new User()
            {
                email = user.email,
                password = user.password
            };
            _context.User.Add(newUser);
            _context.SaveChanges();

            List<User> users = new List<User>();
            users = _context.User.ToList();

            return View("UserInfo", users);
        }
    }
}
