﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GUUI2.Data;
using GUUI2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GUUI2.Controllers
{
    //[Authorize(Policy = "Koekken")]
    public class KoekkenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KoekkenController(ApplicationDbContext context)
        {
            _context = context;
        }


        public ActionResult Kitchen(DateTime givenDate)
        {
            var viewModel = new BookingCheckIn
            {
                CheckIns = _context.CheckIn.ToList(),
                Bookings = _context.Booking.ToList()
            };

            viewModel.Date = givenDate;


            viewModel.CheckIns = viewModel.CheckIns.Where
                (i => i.Dato.Day == givenDate.Day).ToList();
            viewModel.CheckedInVoksne = 0;
            viewModel.CheckedInBoern = 0;
            viewModel.TotalCheckedIn = 0;
            foreach (var guest in viewModel.CheckIns)
            {
                viewModel.CheckedInVoksne += guest.Voksne;
                viewModel.CheckedInBoern += guest.Boern;
                viewModel.TotalCheckedIn = guest.Boern + guest.Voksne;
            }

            viewModel.Bookings = viewModel.Bookings.Where
                (i => i.Dato.Day == givenDate.Day).ToList();
            viewModel.BookedVoksne = 0;
            viewModel.BookedBoern = 0;
            viewModel.TotalBookings = 0;
            foreach (var guest in viewModel.Bookings)
            {
                viewModel.BookedVoksne += guest.Voksne;
                viewModel.BookedBoern += guest.Boern;
                viewModel.TotalBookings = guest.Boern + guest.Voksne;
            }

            return View(viewModel);
        }
    }
}
