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
                .Include(c => c.SosialMedias)
                .Select(c => new ChefListItemVM
                {
                    Id = c.Id,
                    FullName = c.Name + " " + c.Surname,
                    Image = c.Image,
                    Specialization = c.Specialization,
                    Description = c.Description,
                    SocialMediaLinks = c.SosialMedias != null
                        ? c.SosialMedias.Select(sm => sm.Link).ToList()
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateChefVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var chef = await _context.Chefs.FindAsync(vm.Id);
            if (chef == null) return NotFound();

            // Yeni şəkil varsa
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
        // POST: /Chef/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var chef = await _context.Chefs
        //        .Include(c => c.SosialMedias)
        //        .FirstOrDefaultAsync(c => c.Id == id);

        //    if (chef == null) return NotFound();

        //    // Şəkil varsa sil
        //    if (!string.IsNullOrWhiteSpace(chef.Image))
        //    {
        //        chef.Image.DeleteFile(_env.WebRootPath, "assets", "images");
        //    }

        //    // Sosial media bağlantılarını da sil
        //    if (chef.SosialMedias != null && chef.SosialMedias.Any())
        //    {
        //        _context.SosialMedias.RemoveRange(chef.SosialMedias);
        //    }

        //    _context.Chefs.Remove(chef);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}

    }
}
