using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GUUI2.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace GUUI2.Data
{
    public class DbHelper
    {
        public static void SeedData(ApplicationDbContext db, UserManager<IdentityUser> userManager, ILogger log)
        {
            SeedGuests(db, log);
        }

        private static void SeedGuests(ApplicationDbContext db, ILogger log)
        {
            var b = db.Booking.FirstOrDefault();
            if (b == null)
            {
                log.LogInformation("Seeding Booking entries");
                var bookings = new List<Booking>();
                b = new Booking()
                {
                    Dato = new DateTime(2020, 5, 26, 12, 0, 0), //Date: 4-17-2020 (US format) 12:00 o' clock
                    VaerelsesNr = 206,
                    Voksne = 2,
                    Boern = 3

                };
                bookings.Add(b);

                b = new Booking()
                {
                    Dato = new DateTime(2020, 5, 26, 12, 0, 0), //Date: 4-17-2020 (US format) 12:00 o' clock
                    VaerelsesNr = 102,
                    Voksne = 2,
                    Boern = 0
                };
                bookings.Add(b);

                b = new Booking()
                {
                    Dato = new DateTime(2020, 5, 26, 12, 0, 0), //Date: 4-17-2020 (US format) 12:00 o' clock
                    VaerelsesNr = 201,
                    Voksne = 2,
                    Boern = 1
                };
                bookings.Add(b);

                db.Booking.AddRange(bookings);
                db.SaveChangesAsync().Wait();

                var c = db.CheckIn.FirstOrDefault();
                if (c == null)
                {
                    log.LogInformation("Seeding checkIn entries");
                    var checkIns = new List<CheckIn>();
                    c = new CheckIn()
                    {
                        Dato = new DateTime(2020, 5, 26, 12, 0, 0), //Date: 4-17-2020 (US format) 12:00 o' clock
                        VaerelsesNr = 206,
                        Voksne = 1,
                        Boern = 1,
                    };
                    checkIns.Add(c);

                    c = new CheckIn()
                    {
                        Dato = new DateTime(2020, 5, 26, 12, 0, 0), //Date: 4-17-2020 (US format) 12:00 o' clock
                        VaerelsesNr = 102,
                        Voksne = 2,
                        Boern = 0
                    };
                    checkIns.Add(c);

                    c = new CheckIn()
                    {
                        Dato = new DateTime(2020, 5, 26, 12, 0, 0), //Date: 4-17-2020 (US format) 12:00 o' clock
                        VaerelsesNr = 201,
                        Voksne = 2,
                        Boern = 0
                    };
                    checkIns.Add(c);


                    db.CheckIn.AddRange(checkIns);
                    db.SaveChangesAsync().Wait();
                }
            }
        }

    }
}
