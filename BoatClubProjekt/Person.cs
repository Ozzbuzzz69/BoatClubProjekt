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
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Phone number")]
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
