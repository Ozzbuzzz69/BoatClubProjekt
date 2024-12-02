using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.AdminData
{
    public class Admin : Person
    {
        private static int NextId = 0;
        public int Id { get; set; }
        private bool IsAdmin { get; set; }

        public Admin(string name, string address, string email, string telephoneNr, bool isAdmin) : base(name, address, email, telephoneNr)
        {
            Id = ++NextId;
            IsAdmin = isAdmin;
        }

        public override string ToString()
        {
            return $"id: {Id}, name: {Name}, telephonenr: {TelephoneNr}, adress {Address}, email: {Email}";
        }

    }
}
