using CraftMake.Context;
using CraftMake.Models;
using Microsoft.AspNetCore.Mvc;

namespace CraftMake.Controllers
{
    public class SignInController : Controller
    {
        private readonly CraftMakeDatabaseContext _context;
        public SignInController(CraftMakeDatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckUserLogin(User model)
        {
            List<User> users = new List<User>();
            users = _context.User.ToList();
            bool emailMatched = false;
            bool passwordMatched = false;
            // Check if Addmin
            List<Admin> admins = new List<Admin>();
            admins = _context.Admin.ToList();
            foreach (var admin in admins)
            {
                if (model.email == admin.email)
                {
                    emailMatched = true;
                }
                if (model.email == admin.email && model.password == admin.password)
                {
                    passwordMatched = true;
                }
                if (emailMatched && passwordMatched)
                {
                    Admin _admin = _context.Admin.FirstOrDefault(x => x.email == model.email);

                    HttpContext.Session.SetString("AdminSignedIn", _admin.firstName + " " + _admin.lastName);

                    return RedirectToAction("Index", "Home");
                }
            }

            // Check if normal user
            foreach (var user in users)
            {

                if (model.email == user.email)
                {
                    emailMatched = true;
                }
                if (model.email == user.email && model.password == user.password)
                {
                    passwordMatched = true;
                }
            }
            if (!emailMatched)
            {
                ViewBag.userEmailExists = 0;
                return View("Index");
            }
            if (emailMatched && passwordMatched)
            {
                /*ApplicationGlobal.LoggedIn = true;
                ApplicationGlobal.userName = "Sadi";*/
                User _user = _context.User.FirstOrDefault(x => x.email == model.email);
                HttpContext.Session.SetString("SignedIn", _user.firstName + " " + _user.lastName);
                if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetInt32("id") != 0)
                {
                    return RedirectToAction("Details", "Home", new { id = HttpContext.Session.GetInt32("id") });
                }
                if(HttpContext.Session.GetInt32("sellPage") == 1)
                {
                    HttpContext.Session.SetInt32("sellPage", 0);
                    return RedirectToAction("Index", "Product");
                }
                return RedirectToAction("Index", "Home");
                /*return View("../Home/Index", HomeController.products);*/
            }
            if(emailMatched && !passwordMatched)
            {
                ViewBag.passwordNotMatched = 1;
                return View("Index");
            }
            return View("Index");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("SignedIn", "");
            HttpContext.Session.SetString("AdminSignedIn", ""   );
            return View("../Home/Index", HomeController.products);
        }
    }
}
