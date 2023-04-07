using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System
{
    internal class Guest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Guest(string name, string email, string phone) 
        { 
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
        }
    }
}
