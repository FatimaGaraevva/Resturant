using System.ComponentModel.DataAnnotations;

namespace Resturants.ViewModels.MealVM
{
    public class UpdateMenuVM : CreateMenuVM
    {
        [Required]
        public string ExistingImage { get; set; }
    }
}
