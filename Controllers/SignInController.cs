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
            bool isUser = false;
            foreach (var user in users)
            {

                if (model.email == user.email && model.password == user.password)
                {
                    isUser = true;
                }
            }
            if (isUser)
            {
                ApplicationGlobal.LoggedIn = true;
                ApplicationGlobal.userName = "Sadi";
                /*HttpContext.Session.SetString("Key", "Value");*/
                /*ViewBag.value = HttpContext.Session.GetString("Key");*/
                return View("../Home/Index");
            }
            return View("Error");
        }
    }
}
