using Microsoft.AspNetCore.Mvc;
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
                    Description = m.Description,
                   
                    AverageRating = m.Ratings.Any() ? m.Ratings.Average(r => r.Stars) : null,
                    IsAvailable = true // Əgər IsAvailable modeli varsa, əvəz elə
                })
                .ToListAsync();

            return View(meals);
        }

        public async Task<IActionResult> Create()
        {
            return View(new CreateMenuVM
            {
                Chefs = await _context.Chefs.ToListAsync()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMenuVM mealVM)
        {
            mealVM.Chefs = await _context.Chefs.ToListAsync();

            if (!ModelState.IsValid)
                return View(mealVM);

            if (mealVM.Photo is null || !mealVM.Photo.ValidateType("image/") || !mealVM.Photo.ValidateSize(FileSize.KB, 500))
            {
                ModelState.AddModelError(nameof(CreateMenuVM.Photo), "Şəkil tipi və ölçüsü düzgün deyil.");
                return View(mealVM);
            }

            string fileName = await mealVM.Photo.CreateFileAsync(_env.WebRootPath, "assets", "images");

            Menu meal = new Menu
            {
                Name = mealVM.Name,
                Price = mealVM.Price.Value,
                Description = mealVM.Description,
             
                Image = fileName
            };

            await _context.Menus.AddAsync(meal);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id <= 0) return BadRequest();

            Menu? meal = await _context.Menus.FindAsync(id);
            if (meal is null) return NotFound();

            var vm = new UpdateMenuVM
            {
                Name = meal.Name,
                Price = meal.Price,
                Description = meal.Description,
              
                ExistingImage = meal.Image,
                Chefs = await _context.Chefs.ToListAsync()
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, UpdateMenuVM vm)
        {
            vm.Chefs = await _context.Chefs.ToListAsync();
            if (!ModelState.IsValid) return View(vm);

            var meal = await _context.Menus.FindAsync(id);
            if (meal is null) return NotFound();

            if (vm.Photo is not null)
            {
                if (!vm.Photo.ValidateType("image/") || !vm.Photo.ValidateSize(FileSize.KB, 500))
                {
                    ModelState.AddModelError(nameof(UpdateMenuVM.Photo), "File tipi və ölçüsü düzgün deyil.");
                    return View(vm);
                }

                string newImage = await vm.Photo.CreateFileAsync(_env.WebRootPath, "assets", "images" );
                meal.Image.DeleteFile(_env.WebRootPath, "assets", "images");
                meal.Image = newImage;
            }

            meal.Name = vm.Name;
            meal.Price = vm.Price.Value;
            meal.Description = vm.Description;
            

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id <= 0) return BadRequest();

            var meal = await _context.Menus.FindAsync(id);
            if (meal is null) return NotFound();

            meal.Image.DeleteFile(_env.WebRootPath, "assets", "images");
            _context.Menus.Remove(meal);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
