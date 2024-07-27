using Market.Entities;

namespace Market.Models
{
    public class ProductAddViewModel
    {
        public Product Product { get; set; }
        public IFormFile Image { get; set; }
    }
}