﻿
using Microsoft.AspNetCore.Mvc;

namespace BlazorServerMvc6Bundling.Controllers
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
        public IActionResult Simple()
        {
            return View();
        }
        public IActionResult Virtualized()
        {
            return View();
        }

    }
}
