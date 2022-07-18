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

        [HttpPost]
        public ViewResult AddNewUser(User user)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User()
                {
                    firstName = user.firstName,
                    lastName = user.lastName,
                    email = user.email,
                    password = user.password,
                    confirmPassword = user.confirmPassword,
                    country = user.country,
                    address = user.address,
                    town = user.town,
                    phoneNumber = user.phoneNumber
                };
                User alreadyExists = _context.User.FirstOrDefault(user => user.email == newUser.email);
                if (alreadyExists == null)
                {
                    _context.User.Add(newUser);
                    _context.SaveChanges();
                    return View("../SignIn/Index");
                }
            }
            ViewBag.userEmailExists = 1;
            return View("Index");
        }
    }
}
