using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System
{
    internal class Program
    {
        enum Menu
        {
            CadastrarHotel = 1,
            AddRoom = 2,
            CadastraGuest = 3,
            FazerReserva = 4,
            ExibeDados = 5,
            Sair = 6
        }
        static void Main(string[] args)
        {
            Guest guest = null;

            Console.Title = "Hotel System Reservation";
            SystemReservation SystemHotel = new SystemReservation();
            Menu menu = Menu.Sair;
            do
            {
                Console.WriteLine("Digite a opção desejada:\n1-CadastraHotel\n2-Add Room\n3-Cadastrar hóspede\n4-Fazer reserva\n5-Exibir dados\n6- Sair");
                int opcao = int.Parse(Console.ReadLine());
                menu = (Menu)opcao;
                switch (menu)
                {
                    case Menu.CadastrarHotel:
                        Console.WriteLine("Digite o nome do hotel:");
                        string NomeHotel = Console.ReadLine();
                        Console.WriteLine("Capacidade:");
                        int capacity = int.Parse(Console.ReadLine());
                        SystemHotel.AddHotel(NomeHotel, capacity);
                        break;
                    case Menu.AddRoom:
                        Console.WriteLine("Digite a capacidade do quarto:");
                        int capacityRoom = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o número do hotel");
                        int HotelIndex = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o número do quarto");
                        int RoomNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o preço por noite");
                        double PricePerNight = double.Parse(Console.ReadLine());
                        SystemHotel.AddRoom(capacityRoom, HotelIndex, RoomNumber, PricePerNight);
                        break;
                    case Menu.CadastraGuest:
                        Console.WriteLine("Digite o nome do hóspede:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Email:");
                        string email = Console.ReadLine();
                        Console.WriteLine("Telefone");
                        string phone = Console.ReadLine();
                        guest = new Guest(name, email, phone);
                        break;
                    case Menu.FazerReserva:
                        Console.WriteLine("Digite o número da room:");
                        int numeroRoom = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o número do hotel");
                        int HotelIndexR = int.Parse(Console.ReadLine());
                        Console.WriteLine("Date check in:");
                        DateTime checkIn = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Date check out:");
                        DateTime checkOut = DateTime.Parse(Console.ReadLine());
                        SystemHotel.ReserveRoom(numeroRoom, guest, HotelIndexR, checkIn, checkOut);
                        break;
                    case Menu.ExibeDados:
                        Console.WriteLine("Digite o nome do hóspede que deseja buscar");
                        string nomeSearch = Console.ReadLine();
                        List<Reservation> reservations = SystemHotel.GetReservationsByGuest(nomeSearch);
                        foreach (Reservation reservation in reservations)
                        {
                            Console.WriteLine($"Dados da reserva do hóspede: {reservation.Guest.Name}");
                            Console.WriteLine($"Email do hóspede: {reservation.Guest.Email}");
                            Console.WriteLine($"ID: {reservation.Room.Number}");
                            Console.WriteLine($"Check in date: {reservation.CheckIn}");
                            Console.WriteLine($"Check in date: {reservation.CheckOut}");
                        }
                        break;
                }
            } while (menu != Menu.Sair);


            Console.ReadLine();
        }
    }
}
