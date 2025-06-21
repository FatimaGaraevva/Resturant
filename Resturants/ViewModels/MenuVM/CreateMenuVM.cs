using Microsoft.AspNetCore.Mvc.Rendering;
using Resturants.Models;
using System.ComponentModel.DataAnnotations;

namespace Resturants.ViewModels.MealVM
{
    public class CreateMenuVM
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Please select a chef.")]
        public int? ChefId { get; set; }

        [Required(ErrorMessage = "Please upload a photo.")]
        [DataType(DataType.Upload)]
        public IFormFile? Photo { get; set; }

        // Yeni hissə: Ingrediyent seçimi
        [Required(ErrorMessage = "Please select at least one ingredient.")]
        public List<int> SelectedIngredientIds { get; set; } = new();

        public List<SelectListItem>? AllIngredients { get; set; }

        public List<Chef>? Chefs { get; set; }
    }
}

