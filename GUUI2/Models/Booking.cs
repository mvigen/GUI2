using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GUUI2.Models
{
    public class Booking
    {
        [Key]
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public int VaerelsesNr { get; set; }

        public int Voksne { get; set; }

        public int Boern { get; set; }
    }
}
