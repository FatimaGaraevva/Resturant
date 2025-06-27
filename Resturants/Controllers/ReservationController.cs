using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturants.DAL;
using Resturants.Models;
using Resturants.ViewModels;

namespace Resturants.Controllers
{
    public class ReservationController : Controller
    {
        private readonly AppDbContext _context;

        public ReservationController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Menus = await _context.Menus.Take(4).ToListAsync()
            };
            return View(homeVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                // Əgər form Index səhifəsindədirsə, HomeVM yenidən yığılmalıdır
                HomeVM vm = new HomeVM
                {
                    Menus = await _context.Menus.Take(4).ToListAsync(),
                    Reservation = reservation // Əlavə et, əgər modeldə varsa
                };

                return View("Index", vm);
            }

            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Rezervasiya uğurla əlavə olundu!";
            return RedirectToAction(nameof(Index));
        }

    }
}
   
