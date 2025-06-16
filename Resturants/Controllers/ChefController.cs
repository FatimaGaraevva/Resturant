using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturants.DAL;
using Resturants.ViewModels;

namespace Resturants.Controllers
{
    public class ChefController : Controller
    {
        private readonly AppDbContext _context;

        public ChefController(AppDbContext context)
        {
            _context=context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Chefs = await _context.Chefs.Take(3).ToListAsync()
            };
            return View(homeVM);
        }
    }
}
