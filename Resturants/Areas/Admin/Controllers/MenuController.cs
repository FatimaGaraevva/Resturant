using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Resturants.DAL;
using Resturants.Models;
using Resturants.Utilites.Enums;
using Resturants.Utilites.Extensions;
using Resturants.ViewModels.Meal;
using Resturants.ViewModels.MealVM;

namespace Resturants.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public MenuController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var meals = await _context.Menus

                .Include(m => m.Ratings)
                .Select(m => new GetMenuVM
                {
                    Id = m.Id,
                    Name = m.Name,
                    Image = m.Image,
                    Price = m.Price,


                    AverageRating = m.Ratings.Any() ? m.Ratings.Average(r => r.Stars) : null,
                    IsAvailable = true 
                })
                .ToListAsync();

            return View(meals);
        }

        public IActionResult Create()
        {
            var viewModel = new CreateMenuVM
            {
                Chefs = _context.Chefs.ToList(),
                AllIngredients = _context.Ingredients.Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Name
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMenuVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Chefs = await _context.Chefs.ToListAsync();
                model.AllIngredients = await _context.Ingredients.Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Name
                }).ToListAsync();

                return View(model);
            }

            string savedImagePath = null;

            if (model.Photo != null && model.Photo.Length > 0)
            {
                var fileName = Path.GetFileNameWithoutExtension(model.Photo.FileName);
                var extension = Path.GetExtension(model.Photo.FileName);
                var uniqueFileName = $"{fileName}_{Guid.NewGuid()}{extension}";
                var uploads = Path.Combine(_env.WebRootPath, "images", "menus");

                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                var filePath = Path.Combine(uploads, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Photo.CopyToAsync(fileStream);
                }

                savedImagePath = "/images/menus/" + uniqueFileName; 
            }

            var menu = new Menu
            {
                Name = model.Name,
                Price = model.Price!.Value,
                Image = savedImagePath,
                Description = "", 
                Ingredients = await _context.Ingredients
                    .Where(i => model.SelectedIngredientIds.Contains(i.Id))
                    .ToListAsync(),

                ChefMeals = new List<ChefMeal>()
            };

            if (model.ChefId.HasValue)
            {
                menu.ChefMeals.Add(new ChefMeal
                {
                    ChefId = model.ChefId.Value,
                    Meal = menu
                });
            }

            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }




       
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id <= 0) return BadRequest();

            var meal = await _context.Menus
                .Include(m => m.Ingredients)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (meal == null) return NotFound();

            var vm = new UpdateMenuVM
            {
                Id = meal.Id,
                Name = meal.Name,
                Price = meal.Price,

                ExistingImage = meal.Image,
                SelectedIngredientIds = meal.Ingredients.Select(i => i.Id).ToList(),
                AllIngredients = await _context.Ingredients
                    .Select(i => new SelectListItem
                    {
                        Value = i.Id.ToString(),
                        Text = i.Name
                    }).ToListAsync()
            };

            return View(vm);
        }



        [HttpPost]
        public async Task<IActionResult> Update(int? id, UpdateMenuVM vm)
        {
            if (id == null || id <= 0 || id != vm.Id) return BadRequest();

            // Ingredients siyahısını hər halda doldur (validasiya və səhv halında)
            vm.AllIngredients = await _context.Ingredients
                .Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Name
                }).ToListAsync();

            if (!ModelState.IsValid) return View(vm);

            var meal = await _context.Menus
                .Include(m => m.Ingredients)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (meal == null) return NotFound();


            if (vm.ImageFile != null)
            {
                if (!vm.ImageFile.ValidateType("image/") || !vm.ImageFile.ValidateSize(FileSize.KB, 500))
                {
                    ModelState.AddModelError(nameof(UpdateMenuVM.ImageFile), "Şəklin tipi və ya ölçüsü uyğun deyil.");
                    return View(vm);
                }


                string newImage = await vm.ImageFile.CreateFileAsync(_env.WebRootPath, "assets", "images");
                meal.Image.DeleteFile(_env.WebRootPath, "assets", "images");
                meal.Image = newImage;
            }


            meal.Name = vm.Name;
            meal.Price = vm.Price;



            meal.Ingredients.Clear();


            var selectedIngredients = await _context.Ingredients
                .Where(i => vm.SelectedIngredientIds.Contains(i.Id))
                .ToListAsync();

            foreach (var ingredient in selectedIngredients)
            {
                meal.Ingredients.Add(ingredient);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0) return BadRequest();

            var meal = await _context.Menus
                .Include(m => m.ChefMeals)
                .Include(m => m.Ingredients)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (meal == null) return NotFound();

            // Əvvəl əlaqəli qeydləri sil (və ya əlaqələri təmizlə)
            meal.ChefMeals.Clear();       // ChefMeals əlaqələrini təmizlə
            meal.Ingredients.Clear();     // Ingredients əlaqələrini təmizlə

            // Şəkil varsa, faylı sil
            meal.Image?.DeleteFile(_env.WebRootPath, "assets", "images");

            _context.Menus.Remove(meal);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
