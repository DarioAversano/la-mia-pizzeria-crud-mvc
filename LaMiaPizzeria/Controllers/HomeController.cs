﻿using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LaMiaPizzeria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View("Privacy1");
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return View("Contacts");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}