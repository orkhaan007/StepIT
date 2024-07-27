using Market.Entities;

namespace Market.Models
{
    public class ProductUpdateViewModel
    {
        public Product Product { get; set; }
        public IFormFile Image { get; set; }
    }
}