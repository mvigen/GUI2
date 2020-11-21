using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GUUI2.Data;
using GUUI2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GUUI2.Controllers
{
    //[Authorize(Policy = "Reception")]
    public class ReceptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            return View(await _context.CheckIn.ToListAsync());
        }

        public IActionResult Booking()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Dato,VaerelsesNr,Voksne,Boern")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        public async Task<IActionResult> Reception()
        {
            var checkIns = await _context.CheckIn.Where(x => x.Dato.Day == DateTime.Today.Day).ToListAsync();

            return View(checkIns);
        }

        //public async Task<IActionResult> Index(DateTime date)
        //{
        //    if (date.Year == 1)
        //    {
        //        date = DateTime.Today;
        //    }

        //    var checkedIn = (await _context.CheckIn.ToListAsync()).Where(x => x.Dato.Day == date.Day);
        //    return View(checkedIn);
        //}

        public async Task<IActionResult> submit([Bind("noAdults,noKids,date,roomno")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(booking);
        }
    }
}
