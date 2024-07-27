using Menu.Entities;

namespace Menu.Models
{
    public class FoodViewModel
    {
        public List<HotMeal> HotMeals { get; set; } = HotMealsViewModel.HotMeals;
        public List<Drink> Drinks { get; set; } = DrinksViewModel.Drinks;
        public List<FastFood> FastFoods { get; set; } = FastFoodsViewModel.FastFoods;
    }
}