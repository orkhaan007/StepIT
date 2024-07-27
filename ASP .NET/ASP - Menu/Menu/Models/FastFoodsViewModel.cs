using Menu.Entities;

namespace Menu.Models
{
    public class FastFoodsViewModel
    {
        public static List<FastFood> FastFoods { get; set; } = new List<FastFood>()
        {
            new FastFood
            {
                Id = 1,
                Name = "Cheeseburger",
                Description = "Juicy beef patty with melted cheese",
                Price = 5.5,
                isPork = false
            },
            new FastFood
            {
                Id = 2,
                Name = "Chicken Nuggets",
                Description = "Crispy chicken nuggets served with dipping sauce",
                Price = 4.0,
                isPork = false
            },
            new FastFood
            {
                Id = 3,
                Name = "Hot Dog",
                Description = "Classic hot dog with mustard and ketchup",
                Price = 3.0,
                isPork = true
            },
            new FastFood
            {
                Id = 4,
                Name = "French Fries",
                Description = "Golden and crispy fries with a pinch of salt",
                Price = 2.5,
                isPork = false
            },
            new FastFood
            {
                Id = 5,
                Name = "Pizza Slice",
                Description = "Cheesy pizza slice with your choice of toppings",
                Price = 4.5,
                isPork = false
            }
        };
    }
}