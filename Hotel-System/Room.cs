using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System
{
    internal class Room
    {
        public int Number { get; set; }
        public int Capacity { get; set; }
        public double PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
