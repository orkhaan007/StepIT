using Menu.Entities;

namespace Menu.Models
{
    public class HotMealsViewModel
    {
        public static List<HotMeal> HotMeals { get; set; } = new List<HotMeal>()
        {
            new HotMeal
            {
                Id = 1,
                Name = "Beef Stew",
                Description = "Tender beef pieces stewed with vegetables",
                Price = 7.5,
                isSoup = false
            },
            new HotMeal
            {
                Id = 2,
                Name = "Chicken Noodle Soup",
                Description = "Classic chicken soup with noodles and fresh vegetables",
                Price = 6.0,
                isSoup = true
            },
            new HotMeal
            {
                Id = 3,
                Name = "Spaghetti Bolognese",
                Description = "Spaghetti served with a rich and savory meat sauce",
                Price = 8.0,
                isSoup = false
            },
            new HotMeal
            {
                Id = 4,
                Name = "Vegetable Curry",
                Description = "A spicy curry with a variety of fresh vegetables",
                Price = 7.0,
                isSoup = false
            },
            new HotMeal
            {
                Id = 5,
                Name = "Tomato Soup",
                Description = "Smooth and creamy tomato soup with a hint of basil",
                Price = 5.0,
                isSoup = true
            }
        };
    }
}