using Menu.Entities;

namespace Menu.Models
{
    public class DrinksViewModel
    {
        public static List<Drink> Drinks { get; set; } = new List<Drink>()
        {
            new Drink
            {
                Id = 1,
                Name = "Lemonade",
                Price = 2.5,
                Description = "Refreshing lemonade with a hint of mint",
                isCold = true,
                isIced = true
            },
            new Drink
            {
                Id = 2,
                Name = "Orange Juice",
                Price = 3,
                Description = "Freshly squeezed orange juice",
                isCold = true,
                isIced = false
            },
            new Drink
            {
                Id = 3,
                Name = "Hot Chocolate",
                Price = 2.2,
                Description = "Rich and creamy hot chocolate",
                isCold = false,
                isIced = false
            },
            new Drink
            {
                Id = 4,
                Name = "Green Tea",
                Price = 1.5,
                Description = "Hot green tea with a touch of honey",
                isCold = false,
                isIced = false
            },
            new Drink
            {
                Id = 5,
                Name = "Iced Coffee",
                Price = 3.8,
                Description = "Chilled iced coffee with a smooth finish",
                isCold = true,
                isIced = true
            }

        };
    }
}