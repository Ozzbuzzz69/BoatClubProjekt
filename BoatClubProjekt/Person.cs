using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary
{
    public abstract class Person
    {
        protected string Name { get; set; }
        protected string Address { get; set; }
        protected string Email { get; set; }

        public Person() { }
        public Person(string name, string address, string email)
        {
            name = Name;
            address = Address;
            email = Email;
        }
    }
}
