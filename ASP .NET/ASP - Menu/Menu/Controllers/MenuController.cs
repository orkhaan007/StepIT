using Menu.Models;
using Microsoft.AspNetCore.Mvc;

namespace Menu.Controllers
{
    public class MenuController : Controller
    {
        public FoodViewModel vm { get; set; } = new FoodViewModel();

        [HttpGet]
        public IActionResult Index()
        {
            return View(vm);
        }

        [HttpGet]
        public IActionResult FastFoods()
        {
            return View(vm.FastFoods);
        }

        [HttpGet]
        public IActionResult Drinks()
        {
            return View(vm.Drinks);
        }

        [HttpGet]
        public IActionResult HotMeals()
        {
            return View(vm.HotMeals);
        }
    }
}
