using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturants.DAL;
using Resturants.Models;
using Resturants.Utilites.Extensions;
using Resturants.ViewModels.ChefVM;

namespace Resturants.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChefController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ChefController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: /Chef/Index
        public async Task<IActionResult> Index()
        {
            var chefs = await _context.Chefs
                .Include(c => c.SocialMedias)
                .Select(c => new ChefListItemVM
                {
                    Id = c.Id,
                    FullName = c.Name + " " + c.Surname,
                    Image = c.Image,
                    Specialization = c.Specialization,
                    Description = c.Description,
                    SocialMediaLinks = c.SocialMedias != null
                        ? c.SocialMedias.Select(sm => sm.Link).ToList()
                        : new List<string>()
                })
                .ToListAsync();

            return View(chefs);
        }

        // GET: /Chef/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Chef/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateChefVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            string imageName = null;

            if (vm.Photo != null)
            {
                imageName = await vm.Photo.CreateFileAsync(_env.WebRootPath, "assets", "images");
            }

            var chef = new Chef
            {
                Name = vm.Name,
                Surname = vm.Surname,
                Specialization = vm.Specialization,
                Description = vm.Description,
                Image = imageName
            };

            _context.Chefs.Add(chef);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        // GET: /Chef/Update/5
        public async Task<IActionResult> Update(int id)
        {
            var chef = await _context.Chefs.FindAsync(id);
            if (chef == null) return NotFound();

            var vm = new UpdateChefVM
            {
                Id = chef.Id,
                Name = chef.Name,
                Surname = chef.Surname,
                Specialization = chef.Specialization,
                Description = chef.Description,
                ExistingImage = chef.Image // şəkil fayl adı
            };

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateChefVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var chef = await _context.Chefs.FindAsync(vm.Id);
            if (chef == null) return NotFound();

            // Yeni şəkil yüklənibsə
            if (vm.ImageFile is not null)
            {
                if (!string.IsNullOrWhiteSpace(chef.Image))
                {
                    chef.Image.DeleteFile(_env.WebRootPath, "assets", "images");
                }

                chef.Image = await vm.ImageFile.CreateFileAsync(_env.WebRootPath, "assets", "images");
            }

            chef.Name = vm.Name;
            chef.Surname = vm.Surname;
            chef.Specialization = vm.Specialization;
            chef.Description = vm.Description;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var chef = await _context.Chefs
                .Include(c => c.SocialMedias)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (chef == null)
            {
                return NotFound();
            }

            // Şəkil varsa - sil
            if (!string.IsNullOrWhiteSpace(chef.Image))
            {
                string imagePath = Path.Combine(_env.WebRootPath, "assets", "images", chef.Image);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            //Əlaqəli sosial media məlumatlarını sil
            if (chef.SocialMedias?.Any() == true)
            {
                _context.SosialMedias.RemoveRange(chef.SocialMedias);
            }

            _context.Chefs.Remove(chef);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
