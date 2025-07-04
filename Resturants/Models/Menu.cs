﻿namespace Resturants.Models
{
    public class Menu:BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; }
        //reletion

        public List<ChefMeal> ChefMeals { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
