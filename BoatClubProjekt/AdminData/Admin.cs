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

        public Admin(string name, string telephoneNr, string address, string email) : base(name, address, email, telephoneNr)
        {
            Id = ++NextId;

        }
    }
}
