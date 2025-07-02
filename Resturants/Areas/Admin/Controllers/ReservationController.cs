using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturants.DAL;
using Resturants.Interfaces;
using Resturants.Models;
using Resturants.ViewModels.ReservationVM;

namespace Resturants.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

       


      
        public ReservationController(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }


        public async Task<IActionResult> Index()
        {
            var reservations = await _context.Reservations
                .OrderByDescending(r => r.Date)
                .Select(r => new GetReservationVM
                {
                    Id = r.Id,
                    FullName = r.Name,
                    Email = r.Email,
                    Phone = r.PhoneNumber,
                    ReservationDate = r.Date.Date + r.Time
                })
                .ToListAsync();

            return View(reservations);
        }

       
        public async Task<IActionResult> Details(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null) return NotFound();

            var vm = new GetReservationVM
            {
                Id = reservation.Id,
                FullName = reservation.Name,
                Email = reservation.Email,
                Phone = reservation.PhoneNumber,
                ReservationDate = reservation.Date.Date + reservation.Time
            };

            return View(vm);
        }

      
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateReservationVM());
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateReservationVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var reservation = new Reservation
            {
                Name = vm.Name,
                Email = vm.Email,
                PhoneNumber = vm.PhoneNumber,
                NumberOfPeople = vm.NumberOfPeople,
                Date = vm.Date,
                Time = vm.Time
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

       
        public async Task<IActionResult> Edit(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null) return NotFound();

            var vm = new CreateReservationVM
            {
                Name = reservation.Name,
                Email = reservation.Email,
                PhoneNumber = reservation.PhoneNumber,
                NumberOfPeople = reservation.NumberOfPeople,
                Date = reservation.Date,
                Time = reservation.Time
            };

            return View(vm);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateReservationVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null) return NotFound();

            reservation.Name = vm.Name;
            reservation.Email = vm.Email;
            reservation.PhoneNumber = vm.PhoneNumber;
            reservation.NumberOfPeople = vm.NumberOfPeople;
            reservation.Date = vm.Date;
            reservation.Time = vm.Time;

            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null) return NotFound();

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            string subject = "Rezervasiyanız ləğv edildi";
            string body = $"Salam {reservation.Name},<br/><br/>Üzr istəyirik, rezervasiyanız ləğv olundu.";

            await _emailService.SendEmailAsync(reservation.Email, subject, body);

            return RedirectToAction("Index"); // və ya admin panelinə qayıt
        }

    }
}
