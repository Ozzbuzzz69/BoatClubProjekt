using BoatClubLibrary.BoatData;
using BoatClubLibrary.MemberData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.Bookingdata
{
    public class Booking
    {
        public int Id { get; set; }

        public Member MemberId { get; set; }

        public Boat BoatId { get; set; }

        private static int NextId = 1;


        public Booking(Member memberId, Boat boatId)
        {
            Id = NextId++;
            MemberId = memberId;
            BoatId = boatId;
        }

        public override string ToString()
        {
            return $"Id: {Id}, MemberId: {MemberId}, BoatId {BoatId}";
        }
    }
}
