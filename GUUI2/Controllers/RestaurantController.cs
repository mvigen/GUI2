using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GUUI2.Data;
using GUUI2.Models;
using Microsoft.EntityFrameworkCore;

namespace GUUI2.Controllers
{
    //[Authorize(Policy ="Restaurant")]
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RestaurantController(ApplicationDbContext context)
        {
            _context = context;
        }
        //public async Task<IActionResult> Index()
        //{
        //    var Bookings = await _context.Booking.Where(x => x.Dato.Day == DateTime.Today.Day).ToListAsync();

        //    return View(Bookings);
        //}

        public async Task<IActionResult> Index()
        {
            return View(await _context.Booking.ToListAsync());
        }

        public async Task<IActionResult> Restaurant()
        {
            var Bookings = await _context.Booking.Where(x => x.Dato.Day == DateTime.Today.Day).ToListAsync();

            return View(Bookings);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Dato,VaerelsesNr,Voksne,Boern")] CheckIn checkins)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkins);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkins);
        }

        public async Task<IActionResult> Submit([Bind("roomno,NoAdults,noKids")] CheckIn checkIns)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkIns);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(checkIns);
        }
    }
}
