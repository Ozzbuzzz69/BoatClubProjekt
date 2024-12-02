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
        private static int  NextId = 0;
        public int Id { get; set; }
        public string MembershipType { get; set; }
        public string Birthday { get; set; }
        public Member() { }
        public Member(string membershipType, string birthday, string name, string address, string email, string telephoneNr) :  base(name, address, email, telephoneNr)
        {
            Id = ++NextId;
            membershipType = MembershipType;
            birthday = Birthday;
            
        
        }
        public override string ToString()
        {
            return $"ID: {Id} Name: {Name} Address: {Address} Birthday: {Birthday} Email: {Email} Membership Type: {MembershipType}";
        }
    }
}
