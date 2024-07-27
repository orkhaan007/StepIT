using System.ComponentModel.DataAnnotations;

namespace Market.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Range(1, 100, ErrorMessage = "Discount should be between 1 and 100")]
        public ushort Discount { get; set; }

        public string? ImagePath { get; set; }
    }
}
