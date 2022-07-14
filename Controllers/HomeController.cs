﻿using CraftMake.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CraftMake.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details()
        {
            return View();
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
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}