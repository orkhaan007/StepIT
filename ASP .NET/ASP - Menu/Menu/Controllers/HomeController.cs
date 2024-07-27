using Menu.Entities;
using Menu.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Menu.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Menu()
        {
            return View();
        }
    }
}
