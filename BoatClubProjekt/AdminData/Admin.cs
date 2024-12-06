using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.AdminData
{
    public class Admin : Person
    {
        private bool IsAdmin { get; set; }

        private static int NextId = 0;

        public Admin(string name, string address, string email, string phoneNumber, bool isAdmin) : base(name, address, email, phoneNumber)
        {
            Id = ++NextId;
            IsAdmin = isAdmin;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Address {Address}, Email: {Email}, Phonenumber: {PhoneNumber}, Admin: {IsAdmin}";
        }
    }
}
