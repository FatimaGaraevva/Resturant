using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Resturants.ViewModels.MealVM
{
    public class UpdateMenuVM
    {
        [Required]
        public int Id { get; set; } // Menyu ID-si

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public IFormFile? ImageFile { get; set; } // Yeni şəkil üçün

        public string? ExistingImage { get; set; } // Əgər şəkil dəyişmirsə, köhnə şəkil saxlanacaq

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        // Ingredient seçimi üçün əlavə sahə
        [Required(ErrorMessage = "Please select at least one ingredient.")]
        public List<int> SelectedIngredientIds { get; set; } = new();

        // Ingredientləri dropdown və ya multi-select üçün saxlayacaq siyahı
        public List<SelectListItem>? AllIngredients { get; set; }
    }
}
