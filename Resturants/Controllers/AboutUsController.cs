using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturants.DAL;
using Resturants.ViewModels;

namespace Resturants.Controllers
{
    
    public class AboutUsController : Controller
    {
        private readonly AppDbContext _context;

        public AboutUsController(AppDbContext context)
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
