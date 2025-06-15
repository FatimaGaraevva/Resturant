using Resturants.Models;
using System.ComponentModel.DataAnnotations;

namespace Resturants.ViewModels.MealVM
{
    public class CreateMenuVM
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public int? ChefId { get; set; }
        [Required]
        public IFormFile? Photo { get; set; }
        public List<Chef> Chefs { get; set; }
    }
}
