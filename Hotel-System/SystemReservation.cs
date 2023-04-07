using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System
{
    internal class SystemReservation
    {
        public List<Hotel> Hotels { get; set; }

        public SystemReservation()
        {
            Hotels = new List<Hotel>();
        }
        
        public void AddHotel(string name, int capacity)
        {
            Hotel hotel = new Hotel
            { Name = name, 
                Capacity = capacity, 
                Rooms = new List<Room>() 
            };
            Hotels.Add(hotel);
        }
        public void AddRoom(int capacity, int hotelIndex, int roomNumber, double pricePerNight)
        {
            Room room = new Room 
            { 
                Number = roomNumber, 
                Capacity = capacity, 
                IsAvailable = true,
                PricePerNight = pricePerNight, 
                Reservations = new List<Reservation>()
                };
            Hotels[hotelIndex].Rooms.Add(room);
            }
        public void ReserveRoom(int numberRoom, Guest guest, int hotelIndex, DateTime checkIn, DateTime checkOut)
        {
            Room room = Hotels[hotelIndex].Rooms.Find(r => r.Number == numberRoom && r.IsAvailable);
            if(room == null)
            {
                Console.WriteLine("Room not available");
                return;
            }
            double TotalPrice = (checkIn - checkOut).TotalDays * room.PricePerNight;
            Reservation reservation = new Reservation
            {
                Room = room,
                Guest = guest,
                CheckIn = checkIn,
                CheckOut = checkOut
            };

            room.Reservations.Add(reservation);
            room.IsAvailable = false;
            Console.WriteLine("Resercation created!");
            }
        public List<Reservation> GetReservationsByGuest(string name)
        {
            List<Reservation> reservations = new List<Reservation>();
            foreach(Hotel hotel in Hotels)
            {
                foreach(Room room in hotel.Rooms)
                {
                    foreach(Reservation reservation in room.Reservations)
                    {
                        if(reservation.Guest.Name.Equals(name))
                        {
                            reservations.Add(reservation);
                        }
                    }
                }
            }
            
            return reservations;
        }
    }
}
