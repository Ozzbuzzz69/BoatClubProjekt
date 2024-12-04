using BoatClubLibrary.BoatData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BoatClubLibrary.MemberData
{
    public class Member : Person
    {
        public List<Boat> _bookableBoats;

        private static int  NextId = 0;
        [Display(Name = "Member Id")]
        public int Id { get; set; }
        [Display(Name = "Membership Type")]
        public string MembershipType { get; set; }
        [Display(Name = "Member Birthday")]
        public string Birthday { get; set; }
        public bool IsBanned { get; set; }
        public bool IsRenting { get; set; }
        public Member() { }
        public Member(string name, string address, string email, string telephoneNr, string membershipType, string birthday, bool isBanned, bool isRenting) :  base(name, address, email, telephoneNr)
        {
            Id = ++NextId;
            membershipType = MembershipType;
            birthday = Birthday;
            isBanned = IsBanned;
            isRenting = IsRenting;
        }
        
        
        public override string ToString()
        {
            return $"ID: {Id} Name: {Name} Address: {Address} Birthday: {Birthday} Email: {Email} Membership Type: {MembershipType}";
        }
    }
}
