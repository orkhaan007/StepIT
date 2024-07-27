using Market.Entities;
using Market.Models;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> Products { get; set; } = new List<Product>();

        [HttpGet]
        public IActionResult Index()
        {
            var vm = new ProductListViewModel
            {
                Products = Products
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new ProductAddViewModel
            {
                Product = new Product()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(ProductAddViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Image != null)
                {
                    var fileName = Path.GetFileName(vm.Image.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                        vm.Image.CopyTo(stream);
                    vm.Product.ImagePath = "/images/" + fileName;
                }

                vm.Product.Id = (new Random()).Next(10, 1000);
                Products.Add(vm.Product);
                return RedirectToAction("Index");
            }
            else
                return View(vm);
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var item = Products.SingleOrDefault(e => e.Id == id);
            if (item != null)
                Products.Remove(item);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            var vm = new ProductUpdateViewModel
            {
                Product = product
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(ProductUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var product = Products.SingleOrDefault(p => p.Id == vm.Product.Id);
                if (product != null)
                {
                    product.Name = vm.Product.Name;
                    product.Description = vm.Product.Description;
                    product.Price = vm.Product.Price;
                    product.Discount = vm.Product.Discount;

                    if (vm.Image != null)
                    {
                        var fileName = Path.GetFileName(vm.Image.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                            vm.Image.CopyTo(stream);
                        product.ImagePath = "/images/" + fileName;
                    }

                    return RedirectToAction("Index");
                }
                return NotFound();
            }
            return View(vm);
        }
    }
}