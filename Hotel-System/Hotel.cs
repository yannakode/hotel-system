using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System
{
    internal class Hotel
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
