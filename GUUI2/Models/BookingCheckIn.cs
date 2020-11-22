using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GUUI2.Models;

namespace GUUI2.Models
{
    public class BookingCheckIn
    {
        public IEnumerable<CheckIn> CheckIns{ get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
        public int BookedBoern { get; set; }
        public int BookedVoksne { get; set; }
        public int CheckedInBoern { get; set; }
        public int CheckedInVoksne { get; set; }
        public int TotalCheckedIn { get; set; }
        public int TotalBookings { get; set; }
        public DateTime Date { get; set; }
    }
}
