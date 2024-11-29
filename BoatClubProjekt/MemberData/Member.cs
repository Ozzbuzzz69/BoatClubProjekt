using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BoatClubLibrary.MemberData
{
    public class Member : Person
    {
        public static int totalMembers = 0;
        public int Id { get; set; }
        public string MembershipType { get; set; }
        public string Birthday { get; set; }
        public Member() { }
        public Member(string membershipType, string birthday, string name, string address, string email) :  base(name, address, email)
        {
            Id = ++totalMembers;
            membershipType = MembershipType;
            birthday = Birthday;
            name = Name;
            address = Address;
            email = Email;
        
        }
    }
}
