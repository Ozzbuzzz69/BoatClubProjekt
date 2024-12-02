using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.AdminData
{
    public class Admin : Person
    {
        public int Id { get; set; }

        public Admin(int id, string name, string telephoneNr, string address, string email) : base(name, address, email, telephoneNr)
        {
            id = Id;
            
        }
    }
}
