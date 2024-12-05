using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary
{
    public abstract class Person
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public string Email { get; set; }
        
        public string TelephoneNr { get; set; }

        public Person() { }

        public Person(string name, string address, string email, string telephoneNr)
        {
            name = Name;
            address = Address;
            email = Email;
            telephoneNr = TelephoneNr;
        }
    }
}
