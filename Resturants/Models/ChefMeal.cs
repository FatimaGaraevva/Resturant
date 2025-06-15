namespace Resturants.Models
{
    public class ChefMeal:BaseEntity
    {
        public int? ChefId { get; set; }
        public Chef? Chef { get; set; }

        public int? MealId { get; set; }
        public Menu? Meal { get; set; }
    }
}
