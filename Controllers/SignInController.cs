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
            foreach (var user in users)
            {

                if (model.email == user.email)
                {
                    emailMatched = true;
                }
                if(model.email == user.email && model.password == user.password)
                {
                    passwordMatched = true;
                }
            }
            if(!emailMatched)
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
                return RedirectToAction("Index", "Home");
                /*return View("../Home/Index", HomeController.products);*/
            }
            return View("Error");
        }
    }
}
